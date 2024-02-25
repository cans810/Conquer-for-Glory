using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{

    public bool playingAttackAnim;
    public bool isSpawning;

    public void Awake(){
        isSpawning = true;
        gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack_2",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);
        GetComponent<Entity>().animator.SetBool("Spawn",true);
    }

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

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
        if (!GetComponent<Entity>().dead && !isSpawning){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){

                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning && !isSpawning){
                gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack_2",false);
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

    public void stopSpawnAnim(){
        isSpawning = false;
        GetComponent<Entity>().animator.SetBool("Spawn",false);
    }
}
