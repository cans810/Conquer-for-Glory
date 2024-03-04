using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountedSpearManController : MonoBehaviour
{
    public bool playingAttackAnim;
    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 14;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 15;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 15;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.37f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 15;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 14;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 14;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 14;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.39f;
        }
        else if (entity.race.Equals("SeaElf")){
            entity.HP = 16;
            entity.damage = 1.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.39f;
        }
        entity.canGetKnockedBack = true;
        entity.canBurn = true;
        entity.canBeRipped = false;
        entity.canDarkMagicEffect = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!entity.dead){
            if (entity.HitBox.GetComponent<HitBoxController>().colliding && 
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect){

                entity.animator.SetBool("MountedSoldier_Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    entity.animator.SetBool("MountedSpearman_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    entity.animator.SetBool("MountedSpearman_Attack_2",true);
                }
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("MountedSpearman_Attack",false);
                entity.animator.SetBool("MountedSpearman_Attack_2",false);
                entity.animator.SetBool("MountedSoldier_Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("MountedSpearman_Attack",false);
        entity.animator.SetBool("MountedSpearman_Attack_2",false);
    }
}
