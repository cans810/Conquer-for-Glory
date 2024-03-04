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
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingAttackAnim && (float)GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().HP - (float)gameObject.GetComponent<Entity>().damage > 0.0f){
                int randomAttack = UnityEngine.Random.Range(0,2);

                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_2",true);
                }
                else if (randomAttack == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_3",true);
                }

                enemyToRipOff = GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent;
            }
            else if(GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingAttackAnim && (float)GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().HP - (float)gameObject.GetComponent<Entity>().damage <= 0.0f
            && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().canBeRipped){
                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Walk",false);
                
                enemyToRipOff = GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent;
                playingAttackAnim = true;

                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack",true);
            }
            else if(GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingAttackAnim && (float)GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().HP - (float)gameObject.GetComponent<Entity>().damage <= 0.0f
            && !GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>().canBeRipped){
                int randomAttack = UnityEngine.Random.Range(0,2);

                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_2",true);
                }
                else if (randomAttack == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_3",true);
                }

                enemyToRipOff = GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent;
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_3",false);
                gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_2",false);
        gameObject.GetComponent<Entity>().animator.SetBool("OrcBeast_Attack_3",false);
    }

    public void damageEnemy(){
        enemyToRipOff.GetComponent<Entity>().HP -= gameObject.GetComponent<Entity>().damage;
    }

    public void ripEnemy(){
        enemyToRipOff.GetComponent<Entity>().animator.SetBool("Death_3",true);
        enemyToRipOff = null;
    }

    public void playStepSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(0);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
    }
}
