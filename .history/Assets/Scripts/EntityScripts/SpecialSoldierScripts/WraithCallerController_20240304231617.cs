using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WraithCallerController : MonoBehaviour
{

    public bool playingAttackAnim;

    public GameObject rangedHitBox;
    public GameObject skeletonPrefab;

    public int summonableSkeletonCount;

    public GameObject foundEnemy;

    public bool canSummon;
    bool searchingEnemy;
    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("Wraith")){
            entity.HP = 15;
            entity.damage = 0.8f;
            entity.knockbackForce = 1.1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.7f;
            entity.canGetKnockedBack = true;
        }

        summonableSkeletonCount = 6;

        entity.canBurn = false;
        entity.canBeRipped = false;
        entity.canDarkMagicEffect = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (!entity.dead){
            if (!searchingEnemy && summonableSkeletonCount > 0 && !entity.HitBox.GetComponent<HitBoxController>().colliding){
                StartCoroutine(ResetSummonTimer()); 
            }

            if (entity.HitBox.GetComponent<HitBoxController>().colliding && 
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){

                entity.animator.SetBool("WraithCaller_Attack_3",false);
                entity.animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    entity.animator.SetBool("WraithCaller_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    entity.animator.SetBool("WraithCaller_Attack_2",true);
                }
            }
            else if(!entity.HitBox.GetComponent<HitBoxController>().colliding && !rangedHitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && canSummon && summonableSkeletonCount > 0 && foundEnemy != null && !foundEnemy.GetComponent<Entity>().dead){
                entity.animator.SetBool("Walk",false);

                summonSkeletonController();
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                entity.animator.SetBool("WraithCaller_Attack",false);
                entity.animator.SetBool("WraithCaller_Attack_2",false);
                entity.animator.SetBool("WraithCaller_Attack_3",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.animator.SetBool("WraithCaller_Attack",false);
        entity.animator.SetBool("WraithCaller_Attack_2",false);
        entity.animator.SetBool("WraithCaller_Attack_3",false);
    }

    public void summonSkeletonController(){
        if (foundEnemy == null || foundEnemy.GetComponent<Entity>().dead){

        }
        else{
            playingAttackAnim = true;
            entity.animator.SetBool("WraithCaller_Attack_3",true);
            canSummon = false;
        }
    }

    public void summonSkeleton(){

        GameObject skeleton = Instantiate(skeletonPrefab,foundEnemy.transform.position,Quaternion.identity);

        Vector3 offset = new Vector3(0,0,0);

        if (gameObject.tag.Equals("Player")){
            offset = new Vector3(-4f, -0.12f, 0f);
            skeleton.tag = "Player";
            skeleton.GetComponent<EntityCommonActions>().ChangeDirection("right");
            skeleton.GetComponent<Entity>().direction = "right";
            skeleton.GetComponent<Entity>().spawnedAtRow = foundEnemy.GetComponent<Entity>().spawnedAtRow;
        }
        else if (gameObject.tag.Equals("Enemy")){
            offset = new Vector3(+4f, -0.12f, 0f);
            skeleton.tag = "Enemy";
            skeleton.GetComponent<EntityCommonActions>().ChangeDirection("left");
            skeleton.GetComponent<Entity>().direction = "left";
            skeleton.GetComponent<Entity>().spawnedAtRow = foundEnemy.GetComponent<Entity>().spawnedAtRow;
        }

        skeleton.transform.position += offset;
        canSummon = false;
        foundEnemy = null;
        summonableSkeletonCount -= 1;
    }

    public GameObject searchForEnemys(){

        if (tag.Equals("Player")){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, enemies.Length);

                GameObject randomEnemy = enemies[randomIndex];

                foundEnemy = randomEnemy;

                return randomEnemy;
            }
            else
            {
                foundEnemy = null;
                return null;
            }
        }
        else if (tag.Equals("Enemy")){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");

            if (enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, enemies.Length);

                GameObject randomEnemy = enemies[randomIndex];

                foundEnemy = randomEnemy;

                return randomEnemy;
            }
            else
            {
                foundEnemy = null;
                return null;
            }
        }
        else{
            foundEnemy = null;
            return null;
        }
    }

    private IEnumerator ResetSummonTimer()
    {
        searchingEnemy = true;

        if (summonableSkeletonCount > 0 && searchForEnemys() != null && !foundEnemy.GetComponent<Entity>().dead){
            canSummon = true;
        }
        else{
            canSummon = false;
        }

        yield return new WaitForSeconds(2.5f);

        searchingEnemy = false;
    }
}
