using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherController : MonoBehaviour
{

    public GameObject arrowPrefab;
    public GameObject archerArm;

    public bool isWalking;
    public bool isShooting;


    public void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 5;
            entity.damage = 0.7f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 6;
            entity.damage = 0.7f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 5;
            entity.damage = 0.7f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 6;
            entity.damage = 0.7f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.5f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 5;
            entity.damage = 0.9f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.6f;
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
        Vector2 direction = GetDirectionFromEntity();
        int randomAngle = UnityEngine.Random.Range(-5,5);

        direction = Quaternion.Euler(0, 0, randomAngle) * direction;

        GameObject arrowObject = Instantiate(arrowPrefab,archerArm.transform.position,archerArm.transform.rotation);
        arrowObject.GetComponent<ArrowController>().sourceEntity = gameObject;
    }

    Vector2 GetDirectionFromEntity()
    {
        Entity entityComponent = gameObject.GetComponent<Entity>();
        if (entityComponent != null)
        {
            string directionString = entityComponent.direction;
            Vector2 direction = Vector2.zero;

            switch (directionString)
            {
                case "right":
                    direction = Vector2.right;
                    break;
                case "left":
                    direction = Vector2.left;
                    break;
                default:
                    break;
            }

            return direction.normalized;
        }

        return Vector2.zero;
    }

    public void shootingEnded(){
        isShooting = false;
    }
}
