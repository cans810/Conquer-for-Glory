using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEdgedBladeManController : MonoBehaviour
{
    public bool playingAttackAnim;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("Orc")){
            entity.HP = 13;
            entity.damage = 1.5f;
            entity.knockbackForce = 1.3f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.8f;
        }
        entity.canGetKnockedBack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,2);

                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                if (randomAttack == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_2",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_1",true);
                }
                else if (randomAttack == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_1",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_2",true);
                }

                setAttackAnimPlaying();
            }
            else if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && playingAttackAnim && GetComponent<Entity>().gettingKnockedBack){
                playingAttackAnim = false;
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding){
                playingAttackAnim = false;
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleEdgedBladeMan_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void damageOpponentLittle()
    {
        if (gameObject.GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null)
        {
            Entity opponentEntity = gameObject.GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>();
            
            if (opponentEntity != null)
            {
                opponentEntity.HP -= gameObject.GetComponent<Entity>().damage/3;

                Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * gameObject.GetComponent<Entity>().knockbackForce/3, ForceMode2D.Impulse);
                opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                StartCoroutine(gameObject.GetComponent<Entity>().StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
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
