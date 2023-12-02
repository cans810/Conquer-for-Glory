using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Entity : MonoBehaviour
{

    public GameObject HitBox;
    public Animator animator;

    public string race;
    public int HP;
    public float speed;
    public int damage;
    public float knockbackForce;
    public float knockbackDuration;    
    private Coroutine resetVelocityCoroutine;
    public float timeToSummon;
    public bool summonedByPlayer;
    public string direction;
    public string soldierType;

    public void Awake(){

        if (summonedByPlayer){
            direction = "right";
            gameObject.tag = "Player";
            //gameObject.layer = 6;
        }
        else{
            direction = "left";
            //gameObject.tag = "Enemy";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0){
            Destroy(gameObject);
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

                // Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;
                // Rigidbody2D enemyRigidbody = opponentEntity.GetComponent<Rigidbody2D>();

                // if (enemyRigidbody != null)
                // {
                //     enemyRigidbody.velocity = Vector2.zero; // Reset velocity before applying knockback
                //     enemyRigidbody.AddForce(direction, ForceMode2D.Impulse);

                //     if (resetVelocityCoroutine != null)
                //     {
                //         StopCoroutine(resetVelocityCoroutine); // Stop previous coroutine if running
                //     }
                //     resetVelocityCoroutine = StartCoroutine(ResetVelocityAfterKnockback(enemyRigidbody, knockbackDuration));
                // }
            }
        }
    }

    // IEnumerator ResetVelocityAfterKnockback(Rigidbody2D rigidbody, float duration)
    // {
    //     yield return new WaitForSeconds(duration);

    //     if (rigidbody != null)
    //     {
    //         rigidbody.velocity = Vector2.zero;
    //     }
    // }
}
