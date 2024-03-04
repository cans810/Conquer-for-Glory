using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammothController : MonoBehaviour
{

    public bool playingAttackAnim;

    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Wraith")){
            entity.HP = 43;
            entity.damage = 4.7f;
            entity.knockbackForce = 1.7f;
            entity.knockbackDuration = 0.18f;
            entity.speed = 0.26f;

            entity.canGetKnockedBack = false;
        }

        entity.canBurn = true;
        entity.canBeRipped = false;
        entity.canDarkMagicEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,2);

                gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(0);
                    gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack",true);
                }
                else if (randomAttack == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(0);
                    gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack_2",false);
    }

    public void playStepSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(0);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(0);
    }
}
