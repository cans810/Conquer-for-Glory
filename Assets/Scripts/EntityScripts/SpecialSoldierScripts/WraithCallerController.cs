using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithCallerController : MonoBehaviour
{

    public bool playingAttackAnim;

    public GameObject rangedHitBox;
    public GameObject skeletonPrefab;

    public int summonableSkeletonCount;
    public bool isSpawning;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("Wraith")){
            entity.HP = 21;
            entity.damage = 0.8f;
            entity.knockbackForce = 1.1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.7f;
            entity.canGetKnockedBack = true;
        }

        summonableSkeletonCount = 6;
    }

    // Update is called once per frame
    void Update()
    {
        // if there is an enemy in ranged hitbox, summon skeleton soldier from ground, 
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning){

                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack_2",true);
                }
            }
            else if (rangedHitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            rangedHitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning && summonableSkeletonCount > 0){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                playingAttackAnim = true;
                gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack_3",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !rangedHitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning){
                gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack_3",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack_2",false);
        gameObject.GetComponent<Entity>().animator.SetBool("WraithCaller_Attack_3",false);
    }

    public void summonSkeleton(){
        Vector3 offset = new Vector3(2f, 0f, 0f);
        GameObject skeleton = Instantiate(skeletonPrefab,transform.position,Quaternion.identity);

        if (gameObject.tag.Equals("Player")){
            skeleton.tag = "Player";
            skeleton.GetComponent<Entity>().direction = "right";
            skeleton.GetComponent<Entity>().spawnedAtRow = gameObject.GetComponent<Entity>().spawnedAtRow;
        }
        else if (gameObject.tag.Equals("Enemy")){
            skeleton.tag = "Enemy";
            skeleton.GetComponent<Entity>().direction = "left";
            skeleton.GetComponent<Entity>().spawnedAtRow = gameObject.GetComponent<Entity>().spawnedAtRow;
        }

        skeleton.transform.position += offset;
        summonableSkeletonCount -= 1;
    }
}
