using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{

    public GameObject arrowPrefab;
    public GameObject archerArm;

    public bool isWalking;
    public bool isShooting;

    public float arrowLowerAngleBound;
    public float arrowUpperAngleBound;


    public void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 3;
            entity.damage = 0.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 3;
            entity.damage = 0.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 3f;
            entity.damage = 0.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.57f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 3;
            entity.damage = 0.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 4.5f;
            entity.damage = 0.9f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 3;
            entity.damage = 0.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 3;
            entity.damage = 0.4f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }

        isWalking = true;
        entity.canGetKnockedBack = true;
    }

    void Update()
    {
        if (!gameObject.GetComponent<Entity>().dead){

            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !isShooting){
                isShooting = true;
                gameObject.GetComponent<Entity>().animator.SetBool("Archer_Attack",true);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk", false);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack && !isShooting){

                gameObject.GetComponent<Entity>().animator.SetBool("Archer_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);

            }
        }
    }

    public void InstantiateAndShootArrow(){
        GameObject arrowObject = Instantiate(arrowPrefab,archerArm.transform.position,archerArm.transform.rotation);
        arrowObject.GetComponent<ArrowController>().sourceEntity = gameObject;
    }

    public void shootingEnded(){
        isShooting = false;
    }
}
