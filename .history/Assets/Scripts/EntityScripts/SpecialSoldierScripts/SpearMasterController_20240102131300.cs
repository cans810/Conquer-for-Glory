using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMasterController : MonoBehaviour
{
    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("Demon")){
            entity.HP = 20;
            entity.damage = 1.8f;
            entity.knockbackForce = 1.2f;
            entity.knockbackDuration = 0.10f;
            entity.speed = 0.85f;
            entity.canGetKnockedBack = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            AnimatorStateInfo stateInfo = gameObject.GetComponent<Entity>().animator.GetCurrentAnimatorStateInfo(0);

            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && 
            !stateInfo.IsName("SpearMaster_Attack_1") || !stateInfo.IsName("SpearMaster_Attack_2")){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetTrigger("SpearMaster_Attack_1");
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetTrigger("SpearMaster_Attack_2");
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }
}
