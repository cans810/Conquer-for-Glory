using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeManController : MonoBehaviour
{

    public bool playingAttackAnim;
    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 9;
            entity.damage = 2.3f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.67f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.69f;
        }
        else if (entity.race.Equals("SeaElf")){
            entity.HP = 10;
            entity.damage = 2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.69f;
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
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect){

                entity.animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    entity.animator.SetBool("Axeman_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    entity.animator.SetBool("Axeman_Attack_2",true);
                }
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("Axeman_Attack",false);
                entity.animator.SetBool("Axeman_Attack_2",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("Axeman_Attack",false);
        entity.animator.SetBool("Axeman_Attack_2",false);
    }
}
