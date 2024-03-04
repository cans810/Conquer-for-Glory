using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{

    public bool playingAttackAnim;
    public bool isSpawning;

    public void Awake(){
        isSpawning = true;
        entity.animator.SetBool("Swordsman_Attack",false);
        entity.animator.SetBool("Swordsman_Attack_2",false);
        entity.animator.SetBool("Walk",false);
        entity.animator.SetBool("Spawn",true);
    }
    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Wraith")){
            entity.HP = 6f;
            entity.damage = 1.3f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.87f;
        }
        entity.canGetKnockedBack = true;

        entity.canBurn = false;
        entity.canBeRipped = true;
        entity.canDarkMagicEffect = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!entity.dead && !isSpawning){
            if (entity.HitBox.GetComponent<HitBoxController>().colliding && 
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !entity.burning
            && !entity.gettingDarkMagicEffect){

                entity.animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    entity.animator.SetBool("Swordsman_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    entity.animator.SetBool("Swordsman_Attack_2",true);
                }
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !entity.burning && !isSpawning
            && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("Swordsman_Attack",false);
                entity.animator.SetBool("Swordsman_Attack_2",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("Swordsman_Attack",false);
        entity.animator.SetBool("Swordsman_Attack_2",false);
    }

    public void stopSpawnAnim(){
        isSpawning = false;
        entity.animator.SetBool("Spawn",false);
    }
}
