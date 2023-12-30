using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Entity : MonoBehaviour
{

    public GameObject HitBox;
    public Animator animator;

    public string race;
    public float HP;
    public float speed;
    public float damage;
    public float knockbackForce;
    public float knockbackDuration;    
    public bool gettingKnockedBack;
    public bool canGetKnockedBack;
    public float timeToSummon;
    public string direction;
    public string soldierType;
    public bool dead;
    public int spawnedAtRow;

    public void Awake(){
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSpeedValue());
    }

    IEnumerator WaitForSpeedValue()
    {
        while (speed == 0)
        {
            yield return null;
        }
        if (tag.Equals("Player"))
        {
            // apply speed training values
            for (int i = 0; i < GameManager.Instance.playerUpgradeMap["Speed Training"]; i++)
            {
                speed *= 1.05f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && !dead){
            dead = true;
            
            if (GetComponent<BoxCollider2D>() != null)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }

            AnimatorControllerParameter[] parameters = animator.parameters;

            foreach (AnimatorControllerParameter param in parameters)
            {
                if (param.type == AnimatorControllerParameterType.Bool && param.name != "Death")
                {
                    animator.SetBool(param.name, false);
                }
            }
            animator.SetBool("Death", true);

            StartCoroutine(DestroyAfterDelay(5f));

            if (gameObject.tag.Equals("Enemy")){
                GameObject battleController = GameObject.Find("BattleController");
                battleController.GetComponent<BattleController>().enemyDeathCounterUlti += 1;
                battleController.GetComponent<BattleController>().enemyDeathCounterCoin += 1;
            }
            else if (gameObject.tag.Equals("Player")){
                GameObject battleController = GameObject.Find("BattleController");
                battleController.GetComponent<BattleController>().playerDeathCounterUlti += 1;
            }
        }
    }

    public void damageOpponentMelee()
    {
        if (HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null)
        {
            Entity opponentEntity = HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>();
            
            if (opponentEntity != null)
            {
                opponentEntity.HP -= damage;

                if (opponentEntity.canGetKnockedBack){
                    Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                    opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);
                    opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                    StartCoroutine(StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                }
            }
        }
    }

    public IEnumerator StopKnockback(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(knockbackDuration);

        rb.gameObject.GetComponent<Entity>().gettingKnockedBack = false;
        rb.velocity = Vector2.zero;
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }
}
