using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearManController : MonoBehaviour
{

    public void Awake(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 5;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.7f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 6;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.7f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 5;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.7f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 6;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.7f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 4;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.7f;
        }
    }

    void Start(){

    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Spearman_Attack",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack){
                gameObject.GetComponent<Entity>().animator.SetBool("Spearman_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }
}
