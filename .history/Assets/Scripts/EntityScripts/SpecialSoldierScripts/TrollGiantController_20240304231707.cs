using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollGiantController : MonoBehaviour
{

    public bool playingAttackAnim;

    Entity entity;

    public void Start(){
        entity = entity;

        if (entity.race.Equals("Troll")){
            entity.HP = 42;
            entity.damage = 4.0f;
            entity.knockbackForce = 1.7f;
            entity.knockbackDuration = 0.18f;
            entity.speed = 0.34f;

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

                entity.animator.SetBool("Giant_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(1);
                    entity.animator.SetBool("Giant_Attack_2",false);
                    entity.animator.SetBool("Giant_Attack_1",true);
                }
                else if (randomAttack == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(1);
                    entity.animator.SetBool("Giant_Attack_1",false);
                    entity.animator.SetBool("Giant_Attack_2",true);
                }

            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                playingAttackAnim = false;
                entity.animator.SetBool("Giant_Attack_1",false);
                entity.animator.SetBool("Giant_Attack_2",false);
                entity.animator.SetBool("Giant_Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("Giant_Attack_1",false);
        entity.animator.SetBool("Giant_Attack_2",false);
    }

    public void playStepSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(1);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(1);
    }
}
