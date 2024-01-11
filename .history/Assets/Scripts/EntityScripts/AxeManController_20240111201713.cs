using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeManController : MonoBehaviour
{

    public bool playingAttackAnim;
    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 9;
            entity.damage = 2.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.67f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.6f;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 9;
            entity.damage = 1.8f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.14f;
            entity.speed = 0.69f;
        }

        entity.canGetKnockedBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){

                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("Axeman_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("Axeman_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Axeman_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Axeman_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Axeman_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Axeman_Attack_2",false);
    }
}
