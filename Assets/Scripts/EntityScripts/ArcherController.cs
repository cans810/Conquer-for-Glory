using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{

    public GameObject arrowPrefab;
    public GameObject archerArm;

    public bool isWalking;
    public bool shouldShoot;
    public float walkTimer;

    public void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 5;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 6;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 5;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 6;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 4;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }

        isWalking = true;
        shouldShoot = false;
        walkTimer = 0;
        entity.canGetKnockedBack = true;
    }

    void Update()
    {
        if (!gameObject.GetComponent<Entity>().dead){
            if (isWalking && !shouldShoot && !GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack)
            {
                gameObject.GetComponent<Entity>().animator.SetBool("Archer_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
                walkTimer += Time.deltaTime; 
                if (walkTimer >= 2.5f){
                    isWalking = false;
                    shouldShoot = true;
                }
            }
            else if(shouldShoot && !isWalking){
                gameObject.GetComponent<Entity>().animator.SetBool("Archer_Attack",true);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk", false);
            }
        }
    }

    public void InstantiateAndShootArrow(){
        GameObject arrowObject = Instantiate(arrowPrefab,archerArm.transform.position,archerArm.transform.rotation);
        arrowObject.GetComponent<ArrowController>().sourceEntity = gameObject;
    }
}
