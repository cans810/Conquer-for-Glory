using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualBladeChampionController : MonoBehaviour
{

    public bool playingAttackAnim;
    Entity entity;

    public void Start(){
        entity = entity;

        if (entity.race.Equals("Human")){
            entity.HP = 16;
            entity.damage = 1.6f;
            entity.knockbackForce = 1.1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.95f;
            entity.canGetKnockedBack = true;
        }

        entity.canBurn = true;
        entity.canBeRipped = true;
        entity.canDarkMagicEffect = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){

                entity.animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    entity.animator.SetBool("DualBladeChampion_Attack_1",true);
                }
                else if (randomAttackAnim == 1){
                    entity.animator.SetBool("DualBladeChampion_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){
                entity.animator.SetBool("DualBladeChampion_Attack_1",false);
                entity.animator.SetBool("DualBladeChampion_Attack_2",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("DualBladeChampion_Attack_1",false);
        entity.animator.SetBool("DualBladeChampion_Attack_2",false);
    }

    public void damageOpponentLittle()
    {
        if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect)
        {
            Entity opponentEntity = entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>();
            
            if (opponentEntity != null)
            {
                opponentEntity.HP -= entity.damage/2;

                int randomToKnockback = Random.Range(0,10);

                if (randomToKnockback <= 2){
                    if (opponentEntity.canGetKnockedBack){
                        Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                        opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * entity.knockbackForce/2, ForceMode2D.Impulse);
                        opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                        StartCoroutine(entity.StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                    }
                }
            }
        }
    }
}
