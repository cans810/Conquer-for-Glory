using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormBringerController : MonoBehaviour
{

    public bool playingAttackAnim;
    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 34;
            entity.damage = 2.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.85f;
        }
        entity.canGetKnockedBack = true;

        entity.canBurn = true;
        entity.canBeRipped = true;
        entity.canDarkMagicEffect = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!entity.dead){
            if (entity.HitBox.GetComponent<HitBoxController>().colliding && 
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim
            && !entity.gettingDarkMagicEffect){

                entity.animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,100);

                playingAttackAnim = true;
                
                if (randomAttackAnim <= 15){
                    entity.animator.SetBool("StormBringer_Attack_1",true);
                }
                else if (randomAttackAnim > 15 && randomAttackAnim <= 57){
                    entity.animator.SetBool("StormBringer_Attack_2",true);
                }
                else if (randomAttackAnim > 57 && randomAttackAnim <= 100){
                    entity.animator.SetBool("StormBringer_Attack_3",true);
                }
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim
            && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("StormBringer_Attack_1",false);
                entity.animator.SetBool("StormBringer_Attack_2",false);
                entity.animator.SetBool("StormBringer_Attack_3",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void damageSpecialAttack(){
        if (entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null)
        {
            Entity opponentEntity = entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.entity;
            
            if (opponentEntity != null)
            {
                opponentEntity.HP -= entity.damage*6f;

                if (opponentEntity.canGetKnockedBack){
                    Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                    opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * entity.knockbackForce*2f, ForceMode2D.Impulse);
                    opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                    StartCoroutine(entity.StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                }      
            }
        }
    }

    public void startSpecialAttack(){
        entity.canGetKnockedBack = false;
    }

    public void playThunderSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(3);
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.canGetKnockedBack = true;
        entity.animator.SetBool("StormBringer_Attack_1",false);
        entity.animator.SetBool("StormBringer_Attack_2",false);
        entity.animator.SetBool("StormBringer_Attack_3",false);
    }
}
