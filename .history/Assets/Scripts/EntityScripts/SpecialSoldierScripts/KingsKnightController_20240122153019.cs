using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingsKnightController : MonoBehaviour
{

    public bool playingAttackAnim;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("Human")){
            entity.HP = 21;
            entity.damage = 1.9f;
            entity.knockbackForce = 1.1f;
            entity.knockbackDuration = 0.11f;
            entity.speed = 0.65f;
        }
        entity.canGetKnockedBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning){

                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("KingsKnight_Attack_1",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("KingsKnight_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning){
                gameObject.GetComponent<Entity>().animator.SetBool("KingsKnight_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("KingsKnight_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("KingsKnight_Attack_1",false);
        gameObject.GetComponent<Entity>().animator.SetBool("KingsKnight_Attack_2",false);
    }
}
