using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearThrowerController : MonoBehaviour
{

    public GameObject spearPrefab;
    public GameObject spearArm;

    public bool isWalking;
    public bool isShooting;

    public float arrowLowerAngleBound;
    public float arrowUpperAngleBound;
    public float forwardForce = 5f;


    public void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        // only sea elf
        if (entity.race.Equals("SeaElf")){
            entity.HP = 4.5f;
            entity.damage = 0.8f;
            entity.knockbackForce = 1.2f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.6f;

            arrowLowerAngleBound = -6;
            arrowUpperAngleBound = 6;
        }

        isWalking = true;
        entity.canGetKnockedBack = true;
        entity.canBurn = true;
        entity.canBeRipped = true;
    }

    void Update()
    {
        if (!gameObject.GetComponent<Entity>().dead){

            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !isShooting && !GetComponent<Entity>().burning){
                isShooting = true;
                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playArrowSound(1);
                gameObject.GetComponent<Entity>().animator.SetBool("SpearThrower_Attack",true);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk", false);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack && !isShooting && !GetComponent<Entity>().burning){

                gameObject.GetComponent<Entity>().animator.SetBool("SpearThrower_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);

            }
        }
    }

    public void InstantiateAndThrowSpear(){
        GameObject spearObject = Instantiate(spearPrefab,spearArm.transform.position,spearArm.transform.rotation);
        spearObject
        spearObject.GetComponent<ThrowableSpearController>().sourceEntity = gameObject;
    }

    public void shootingEnded(){
        isShooting = false;
    }
}
