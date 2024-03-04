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


    Entity entity;

    public void Start(){
        entity = entity;

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
        entity.canDarkMagicEffect = true;
    }

    void Update()
    {
        if (!entity.dead){

            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !isShooting && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){
                isShooting = true;
                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playArrowSound(1);
                entity.animator.SetBool("SpearThrower_Attack",true);
                entity.animator.SetBool("Walk", false);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack && !isShooting && !GetComponent<Entity>().burning
            && !GetComponent<Entity>().gettingDarkMagicEffect){

                entity.animator.SetBool("SpearThrower_Attack",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);

            }
        }
    }

    public void InstantiateAndThrowSpear(){
        GameObject spearObject = Instantiate(spearPrefab,spearArm.transform.position,spearArm.transform.rotation);
        spearObject.GetComponent<ThrowableSpearController>().sourceEntity = gameObject;
    }

    public void shootingEnded(){
        isShooting = false;
    }
}
