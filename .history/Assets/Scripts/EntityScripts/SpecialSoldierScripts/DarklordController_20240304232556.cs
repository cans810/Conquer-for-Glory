using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarklordController : MonoBehaviour
{

    public bool playingAttackAnim;

    public bool canTeleport;
    public bool teleportCondition;
    public int teleportCount;

    public GameObject foundEnemy;
    public GameObject rangedHitbox;

    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Demon")){
            entity.HP = 20;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.78f;
        }
        entity.canGetKnockedBack = true;

        entity.canBurn = false;
        entity.canBeRipped = true;
        entity.canDarkMagicEffect = true;

        canTeleport = false;
        teleportCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (!entity.dead){
            if (!teleportCondition && teleportCount > 0){
                StartCoroutine(ResetTeleportTimer()); 
            }

            if (entity.HitBox.GetComponent<HitBoxController>().colliding && 
            entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim 
            && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    entity.animator.SetBool("Darklord_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    entity.animator.SetBool("Darklord_Attack_2",true);
                }
            }
            else if(!entity.HitBox.GetComponent<HitBoxController>().colliding && !rangedHitbox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && canTeleport && teleportCount > 0 && foundEnemy != null && !foundEnemy.entity.dead
            && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("Walk",false);

                playingAttackAnim = true;
                entity.canGetKnockedBack = false;
                entity.animator.SetBool("Teleport_1",true);
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !entity.gettingDarkMagicEffect){
                entity.animator.SetBool("Darklord_Attack",false);
                entity.animator.SetBool("Darklord_Attack_2",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void teleportOnFoundEnemy(){
        if (gameObject.tag.Equals("Player")){
            transform.position = new Vector3(foundEnemy.transform.position.x - 3f,foundEnemy.transform.position.y,foundEnemy.transform.position.z);
            entity.spawnedAtRow = foundEnemy.GetComponent<Entity>().spawnedAtRow;
        }
        else if (gameObject.tag.Equals("Enemy")){
            transform.position = new Vector3(foundEnemy.transform.position.x + 3f,foundEnemy.transform.position.y,foundEnemy.transform.position.z);
            entity.spawnedAtRow = foundEnemy.GetComponent<Entity>().spawnedAtRow;
        }

        GetComponent<EntitySortingLayerController>().SetSortingLayer(transform);

        canTeleport = false;
        teleportCount -= 1;
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        entity.canGetKnockedBack = true;
        entity.animator.SetBool("Darklord_Attack",false);
        entity.animator.SetBool("Darklord_Attack_2",false);
    }

    public void stopTeleportAnim1(){
        entity.animator.SetBool("Teleport_1",false);
        entity.animator.SetBool("Teleport_2",true);
    }

    public void stopTeleportAnim2(){
        playingAttackAnim = false;
        entity.canGetKnockedBack = true;
        entity.animator.SetBool("Teleport_2",false);
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

    private IEnumerator ResetTeleportTimer()
    {
        teleportCondition = true;

        float randomTimeSeconds = Random.Range(4.5f,8f);

        yield return new WaitForSeconds(randomTimeSeconds);

        if (teleportCount > 0 && searchForEnemys() != null && !foundEnemy.entity.dead){
            canTeleport = true;
        }
        else{
            canTeleport = false;
        }

        teleportCondition = false;
    }
}
