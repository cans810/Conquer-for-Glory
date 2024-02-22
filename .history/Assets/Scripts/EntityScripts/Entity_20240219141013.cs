using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Entity : MonoBehaviour
{
    public string soldierID;

    public GameObject HitBox;
    public Animator animator;

    public string race;
    public float HP;
    public float speed;
    public float damage;
    public float knockbackForce;
    public float knockbackDuration;    
    public bool gettingKnockedBack;
    public bool burning;
    public bool canGetKnockedBack;
    public bool canBeRipped;
    public bool canBurn;
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
        StartCoroutine(SetSpeedTrainingAfterWaiting());

        StartCoroutine(SetArmourIncreaseAfterWaiting());

        if (soldierType.Equals("Archer")){
            StartCoroutine(SetArcheryAfterWaiting());
        }


    }

    IEnumerator SetSpeedTrainingAfterWaiting()
    {
        while (speed == 0)
        {
            yield return null;
        }
        if (tag.Equals("Player"))
        {
            // apply speed training values
            for (int i = 0; i < GameManager.Instance.speedTrainingPoint; i++)
            {
                speed *= 1.05f;
            }
        }
    }

    IEnumerator SetArmourIncreaseAfterWaiting()
    {
        while (HP == 0)
        {
            yield return null;
        }
        if (tag.Equals("Player"))
        {
            // apply armour increase values
            for (int i = 0; i < GameManager.Instance.armourIncreasePoint; i++)
            {
                HP *= 1.02f;
            }
        }
    }

    IEnumerator SetArcheryAfterWaiting()
    {
        while (GetComponent<ArcherController>().arrowLowerAngleBound == 0 && GetComponent<ArcherController>().arrowUpperAngleBound == 0)
        {
            yield return null;
        }
        if (tag.Equals("Player"))
        {
            for (int i = 0; i < GameManager.Instance.archeryPoint; i++)
            {
                GetComponent<ArcherController>().arrowLowerAngleBound += 1.5f;
                GetComponent<ArcherController>().arrowUpperAngleBound -= 1.5f;
                GetComponent<ArcherController>().forwardForce += 0.5f;
            }
        }
    }

    IEnumerator AdjustSoldierDifficulty(){
        while (speed == 0)
        {
            yield return null;
        }
        if (tag.Equals("Enemy"))
        {
            // adjust speed values
            for (int i = 0; i < GameManager.Instance.DynamicDifficulty; i++)
            {
                speed *= 1.005f;
            }
            // adjust armour values
            for (int i = 0; i < GameManager.Instance.DynamicDifficulty; i++)
            {
                HP *= 1.005f;
            }
            // adjust archer values
            for (int i = 0; i < GameManager.Instance.DynamicDifficulty; i++)
            {
                GetComponent<ArcherController>().arrowLowerAngleBound += 0.2f;
                GetComponent<ArcherController>().arrowUpperAngleBound -= 0.2f;
                GetComponent<ArcherController>().forwardForce += 0.02f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && !dead){
            GameObject killedBy = HitBox.GetComponent<HitBoxController>().currentHittingOpponent;

            dead = true;
            
            if (GetComponent<BoxCollider2D>() != null)
            {
                GetComponent<BoxCollider2D>().enabled = false;
            }

            AnimatorControllerParameter[] parameters = animator.parameters;

            foreach (AnimatorControllerParameter param in parameters)
             {
                if (param.type == AnimatorControllerParameterType.Bool && param.name != "Death" || param.name != "Death_2"
                || param.name != "Death_3")
                {
                    animator.SetBool(param.name, false);
                }
            }

            if (canBeRipped){
                if (killedBy && killedBy.GetComponent<Entity>().soldierType.Equals("OrcBeast")){
                
                }
                else{
                    int randomDeathAnim = UnityEngine.Random.Range(0,2);

                    if (randomDeathAnim == 0){
                        animator.SetBool("Death", true);
                    }
                    if (randomDeathAnim == 1){
                        animator.SetBool("Death_2", true);
                    }
                }

                if (gameObject.transform.Find("SoundManager")){
                    EntitySoundManager entitySounds = gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>();
                    
                    entitySounds.playDeathSound();
                }
            }
            else{
                animator.SetBool("Death", true);
            }

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

                // eğer mammoth, trollgiant veya easternlion ise o zaman %100 karşı tarafı knockbackleyebiliyor ve klasik insan sesleri çıkartmıyor 
                if (soldierType == "Mammoth" || soldierType == "TrollGiant" || soldierType == "EasternLion" 
                || soldierType == "Minotaur" || soldierType == "Dragon" || soldierType == "WraithCaller" 
                || soldierType == "OrcBeast"){
                    if (opponentEntity.canGetKnockedBack){
                        Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                        opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);
                        opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                        StartCoroutine(StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                    }
                    if (soldierType == "Minotaur"){
                        EntitySoundManager entitySounds = gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>();
                        
                        entitySounds.playWeaponSound();
                    }
                }

                // eğer mammoth, trollgiant veya easternlion değilse kendisi, o zaman %30 ihtimalle karşı tarafı knockbackleyebiliyor ve insan sesleri çıkartıyor
                else{
                    if (gameObject.transform.Find("SoundManager")){
                        EntitySoundManager entitySounds = gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>();
                        
                        entitySounds.playWeaponSound();
                    }

                    int randomToKnockback = UnityEngine.Random.Range(0,10);

                    if (opponentEntity.gameObject.transform.Find("SoundManager")){
                        EntitySoundManager entitySounds = opponentEntity.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>();
                    
                        entitySounds.playHurtSound();
                    }

                    if (randomToKnockback <= 2){
                        if (opponentEntity.canGetKnockedBack){
                            Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                            opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * knockbackForce, ForceMode2D.Impulse);
                            opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                            StartCoroutine(StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                        }
                    }
                    
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

    public void applyBloodColor(){
        gameObject.transform.Find("Effects").GetComponent<SpriteRenderer>().color = gameObject.transform.Find("Effects").GetComponent<EffectsManager>().bloodColor; 
    }

}
