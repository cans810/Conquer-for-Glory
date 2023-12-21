using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountedSpearManController : MonoBehaviour
{
    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 14;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 15;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 15;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 15;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 14;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 1.3f;
        }
        entity.canGetKnockedBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null){
                gameObject.GetComponent<Entity>().animator.SetBool("MountedSoldier_Walk",false);
                gameObject.GetComponent<Entity>().animator.SetBool("MountedSpearman_Attack",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding){
                gameObject.GetComponent<Entity>().animator.SetBool("MountedSpearman_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("MountedSoldier_Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }
}
