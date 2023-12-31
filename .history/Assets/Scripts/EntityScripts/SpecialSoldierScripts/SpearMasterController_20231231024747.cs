using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearMasterController : MonoBehaviour
{

    public bool playingAttackAnim;

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
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,2);

                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                if (randomAttack == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_2",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_1",true);
                }
                else if (randomAttack == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_1",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_2",true);
                }

                setAttackAnimPlaying();
            }
            else if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && playingAttackAnim && GetComponent<Entity>().gettingKnockedBack){
                playingAttackAnim = false;
                gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                playingAttackAnim = false;
                gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("SpearMaster_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void setAttackAnimPlaying(){
        playingAttackAnim = true;
    }
    public void AttackAnimOver(){
        playingAttackAnim = false;

    }
}
