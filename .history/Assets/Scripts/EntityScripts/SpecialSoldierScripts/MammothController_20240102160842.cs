using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MammothController : MonoBehaviour
{

    public bool playingAttackAnim;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Wraith")){
            entity.HP = 55;
            entity.damage = 5f;
            entity.knockbackForce = 1.7f;
            entity.knockbackDuration = 0.18f;
            entity.speed = 0.23f;

            entity.canGetKnockedBack = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,1);

                gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Walk",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack",true);
                }


                setAttackAnimPlaying();
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                playingAttackAnim = false;
                gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Attack",false);
                //gameObject.GetComponent<Entity>().animator.SetBool("Giant_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Mammoth_Walk",true);
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
