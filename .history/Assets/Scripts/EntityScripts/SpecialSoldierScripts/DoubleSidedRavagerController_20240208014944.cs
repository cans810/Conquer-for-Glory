using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSidedRavagerController : MonoBehaviour
{

    public bool playingAttackAnim;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("Orc")){
            entity.HP = 19;
            entity.damage = 1.8f;
            entity.knockbackForce = 1.3f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.8f;
        }
        entity.canGetKnockedBack = true;

        entity.canBurn = true;
        entity.canBeRipped = true;
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
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_1",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning){
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_1",false);
        gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_2",false);
    }

    public void damageOpponentLittle()
    {
        if (gameObject.GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null)
        {
            Entity opponentEntity = gameObject.GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>();
            
            if (opponentEntity != null)
            {
                opponentEntity.HP -= gameObject.GetComponent<Entity>().damage/3;

                int randomToKnockback = Random.Range(0,10);

                if (randomToKnockback <= 2){
                    if (opponentEntity.canGetKnockedBack){
                        Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                        opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * gameObject.GetComponent<Entity>().knockbackForce/3, ForceMode2D.Impulse);
                        opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                        StartCoroutine(gameObject.GetComponent<Entity>().StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                    }
                }
            }
        }
    }
}
