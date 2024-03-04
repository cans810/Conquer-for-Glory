using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueensKnightController : MonoBehaviour
{

    public bool playingAttackAnim;

    Entity entity;

    public void Start(){
        entity = entity;

        // only for elfs
        if (entity.race.Equals("Elf")){
            entity.HP = 19;
            entity.damage = 1.9f;
            entity.knockbackForce = 1.1f;
            entity.knockbackDuration = 0.11f;
            entity.speed = 0.65f;
        }
        entity.canGetKnockedBack = true;

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
                    entity.animator.SetBool("QueensKnight_Attack_1",true);
                }
                else if (randomAttackAnim == 1){
                    entity.animator.SetBool("QueensKnight_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){
                entity.animator.SetBool("QueensKnight_Attack_1",false);
                entity.animator.SetBool("QueensKnight_Attack_2",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("QueensKnight_Attack_1",false);
        entity.animator.SetBool("QueensKnight_Attack_2",false);
    }
}
