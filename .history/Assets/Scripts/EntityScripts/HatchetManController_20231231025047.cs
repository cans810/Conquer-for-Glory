using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatchetManController : MonoBehaviour
{
    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 7;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.85f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 7;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.85f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 7;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.85f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 7;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.85f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 7;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.85f;
        }
        entity.canGetKnockedBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Hatchetman_Attack",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack){
                gameObject.GetComponent<Entity>().animator.SetBool("Hatchetman_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }
}
