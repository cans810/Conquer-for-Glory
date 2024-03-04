using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcBeastController : MonoBehaviour
{
    public bool playingAttackAnim;

    GameObject enemyToRipOff;

    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Orc")){
            entity.HP = 40;
            entity.damage = 3.2f;
            entity.knockbackForce = 1.6f;
            entity.knockbackDuration = 0.12f;
            entity.speed = 0.4f;

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
            if (entity.HitBox.GetComponent<HitBoxController>().colliding && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingAttackAnim && (float)entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().HP - (float)entity.damage > 0.0f){
                int randomAttack = UnityEngine.Random.Range(0,2);

                entity.animator.SetBool("OrcBeast_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    entity.animator.SetBool("OrcBeast_Attack_2",true);
                }
                else if (randomAttack == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    entity.animator.SetBool("OrcBeast_Attack_3",true);
                }

                enemyToRipOff = entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent;
            }
            else if(entity.HitBox.GetComponent<HitBoxController>().colliding && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingAttackAnim && (float)entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().HP - (float)entity.damage <= 0.0f
            && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().canBeRipped){
                entity.animator.SetBool("OrcBeast_Walk",false);
                
                enemyToRipOff = entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent;
                playingAttackAnim = true;

                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                entity.animator.SetBool("OrcBeast_Attack",true);
            }
            else if(entity.HitBox.GetComponent<HitBoxController>().colliding && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingAttackAnim && (float)entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().HP - (float)entity.damage <= 0.0f
            && !entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().canBeRipped){
                int randomAttack = UnityEngine.Random.Range(0,2);

                entity.animator.SetBool("OrcBeast_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    entity.animator.SetBool("OrcBeast_Attack_2",true);
                }
                else if (randomAttack == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    entity.animator.SetBool("OrcBeast_Attack_3",true);
                }

                enemyToRipOff = entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent;
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                entity.animator.SetBool("OrcBeast_Attack",false);
                entity.animator.SetBool("OrcBeast_Attack_2",false);
                entity.animator.SetBool("OrcBeast_Attack_3",false);
                entity.animator.SetBool("OrcBeast_Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("OrcBeast_Attack",false);
        entity.animator.SetBool("OrcBeast_Attack_2",false);
        entity.animator.SetBool("OrcBeast_Attack_3",false);
    }

    public void damageEnemy(){
        enemyToRipOff.entity.HP -= entity.damage;
    }

    public void ripEnemy(){
        enemyToRipOff.entity.animator.SetBool("Death_3",true);
        enemyToRipOff = null;
    }

    public void playStepSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(0);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
    }
}
