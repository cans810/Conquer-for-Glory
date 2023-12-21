using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollGiantController : MonoBehaviour
{

    public bool playingAttackAnim;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Troll")){
            entity.HP = 40;
            entity.damage = 4f;
            entity.knockbackForce = 1.8f;
            entity.knockbackDuration = 0.25f;
            entity.speed = 0.4f;

            entity.canGetKnockedBack = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,2);

                gameObject.GetComponent<Entity>().animator.SetBool("Giant_Walk",false);

                if (randomAttack == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("Giant_Attack_2",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("Giant_Attack_1",true);
                }
                else if (randomAttack == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("Giant_Attack_1",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("Giant_Attack_2",true);
                }

                setAttackAnimPlaying();
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding){
                playingAttackAnim = false;
                gameObject.GetComponent<Entity>().animator.SetBool("Giant_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Giant_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Giant_Walk",true);
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
