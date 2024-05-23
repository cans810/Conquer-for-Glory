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
    public float forwardForce = 5f;

    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 3;
            entity.damage = 0.6f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 3;
            entity.damage = 0.6f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 3f;
            entity.damage = 0.6f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.57f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 3;
            entity.damage = 0.6f;
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

            arrowLowerAngleBound = -6.5f;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 3;
            entity.damage = 0.6f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 3;
            entity.damage = 0.6f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.59f;

            arrowLowerAngleBound = -7;
            arrowUpperAngleBound = 7;
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

            if (entity.HitBox.GetComponent<HitBoxController>().colliding && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !isShooting && !entity.burning
            && !entity.gettingDarkMagicEffect){
                isShooting = true;
                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playArrowSound(1);
                entity.animator.SetBool("Archer_Attack",true);
                entity.animator.SetBool("Walk", false);
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !entity.gettingKnockedBack && !isShooting && !entity.burning
            && !entity.gettingDarkMagicEffect){

                entity.animator.SetBool("Archer_Attack",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);

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
