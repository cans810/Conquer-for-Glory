using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinotaurController : MonoBehaviour
{
    public bool playingAttackAnim;

    Entity entity;

    public void Start(){
        entity = entity;

        if (entity.race.Equals("Elf")){
            entity.HP = 37;
            entity.damage = 3.6f;
            entity.knockbackForce = 1.7f;
            entity.knockbackDuration = 0.12f;
            entity.speed = 0.67f;

            entity.canGetKnockedBack = false;
        }

        entity.canBurn = true;
        entity.canBeRipped = false;
        entity.canDarkMagicEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!entity.dead){
            if (entity.HitBox.GetComponent<HitBoxController>().colliding && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,2);

                entity.animator.SetBool("Minotaur_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
                    entity.animator.SetBool("Minotaur_Attack",true);
                }
                else if (randomAttack == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
                    entity.animator.SetBool("Minotaur_Attack_2",true);
                }
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                entity.animator.SetBool("Minotaur_Attack",false);
                entity.animator.SetBool("Minotaur_Attack_2",false);
                entity.animator.SetBool("Minotaur_Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("Minotaur_Attack",false);
        entity.animator.SetBool("Minotaur_Attack_2",false);
    }

    public void playStepSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(0);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
    }
}
