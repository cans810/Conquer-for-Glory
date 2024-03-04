using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualBladeChampionController : MonoBehaviour
{

    public bool playingAttackAnim;
    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

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
        if (!entity.dead){
            if (entity.HitBox.GetComponent<HitBoxController>().colliding && 
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect){

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
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("DualBladeChampion_Attack_1",false);
                entity.animator.SetBool("DualBladeChampion_Attack_2",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
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
        if (entity.HitBox.GetComponent<HitBoxController>().colliding && 
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect)
        {
            Entity opponentEntity = entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.entity;
            
            if (opponentEntity != null)
            {
                opponentEntity.HP -= entity.damage/2;

                int randomToKnockback = Random.Range(0,10);

                if (randomToKnockback <= 2){
                    if (opponentEntity.canGetKnockedBack){
                        Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                        opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * entity.knockbackForce/2, ForceMode2D.Impulse);
                        opponentEntity.G.gettingKnockedBack = true;

                        StartCoroutine(entity.StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                    }
                }
            }
        }
    }
}
