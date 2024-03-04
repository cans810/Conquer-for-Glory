using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsManController : MonoBehaviour
{

    public bool playingAttackAnim;
    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 9;
            entity.damage = 1.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 7;
            entity.damage = 1.7f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 7;
            entity.damage = 1.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.72f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 7;
            entity.damage = 1.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 7f;
            entity.damage = 1.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 9f;
            entity.damage = 1.7f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 7f;
            entity.damage = 1.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.74f;
        }
        else if (entity.race.Equals("SeaElf")){
            entity.HP = 9f;
            entity.damage = 1.6f;
            entity.knockbackForce = 1.1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.74f;
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
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){

                entity.animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){
                entity.animator.SetBool("Swordsman_Attack",false);
                entity.animator.SetBool("Swordsman_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack_2",false);
    }
}
