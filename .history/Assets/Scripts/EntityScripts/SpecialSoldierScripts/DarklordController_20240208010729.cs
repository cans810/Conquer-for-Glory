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

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Demon")){
            entity.HP = 25;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.78f;
        }
        entity.canGetKnockedBack = true;

        entity.canBurn = false;
        entity.canBeRipped = true;

        canTeleport = false;
        teleportCount = 4;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (!teleportCondition && teleportCount > 0){
                StartCoroutine(ResetTeleportTimer()); 
            }

            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("Darklord_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("Darklord_Attack_2",true);
                }
            }
            else if(!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && canTeleport && teleportCount > 0 && foundEnemy != null && !foundEnemy.GetComponent<Entity>().dead){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                playingAttackAnim = true;
                gameObject.GetComponent<Entity>().canGetKnockedBack = false;
                gameObject.GetComponent<Entity>().animator.SetBool("Teleport_1",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Darklord_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Darklord_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void teleportOnFoundEnemy(){
        if (gameObject.tag.Equals("Player")){
            transform.position = new Vector3(foundEnemy.transform.position.x - 3f,foundEnemy.transform.position.y,foundEnemy.transform.position.z);
            GetComponent<Entity>().spawnedAtRow = foundEnemy.GetComponent<Entity>().spawnedAtRow;
        }
        else if (gameObject.tag.Equals("Enemy")){
            transform.position = new Vector3(foundEnemy.transform.position.x + 3f,foundEnemy.transform.position.y,foundEnemy.transform.position.z);
            GetComponent<Entity>().spawnedAtRow = foundEnemy.GetComponent<Entity>().spawnedAtRow;
        }

        GetComponent<EntitySortingLayerController>().SetSortingLayer(transform);

        playingAttackAnim = true;
        gameObject.GetComponent<Entity>().animator.SetBool("Teleport_2",true);

        canTeleport = false;
        teleportCount -= 1;
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().canGetKnockedBack = true;
        gameObject.GetComponent<Entity>().animator.SetBool("Darklord_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Darklord_Attack_2",false);
    }

    public void stopTeleportAnim1(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().canGetKnockedBack = true;
        gameObject.GetComponent<Entity>().animator.SetBool("Teleport_1",false);
    }


    public void stopTeleportAnim2(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().canGetKnockedBack = true;
        gameObject.GetComponent<Entity>().animator.SetBool("Teleport_2",false);
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

        yield return new WaitForSeconds(6f);

        if (teleportCount > 0 && searchForEnemys() != null && !foundEnemy.GetComponent<Entity>().dead){
            canTeleport = true;
        }
        else{
            canTeleport = false;
        }

        teleportCondition = false;
    }
}
