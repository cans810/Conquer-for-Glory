using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormBringerController : MonoBehaviour
{

    public bool playingAttackAnim;
    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 26;
            entity.damage = 2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.9f;
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

                int randomAttackAnim = Random.Range(0,5);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("StormBringer_Attack",true);
                }
                else if (randomAttackAnim >= 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("StormBringer_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("StormBringer_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("StormBringer_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("StormBringer_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("StormBringer_Attack_2",false);
    }
}
