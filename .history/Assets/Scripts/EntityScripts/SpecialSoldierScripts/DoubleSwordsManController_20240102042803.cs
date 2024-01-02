using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSwordsManController : MonoBehaviour
{
    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("Elf")){
            entity.HP = 14;
            entity.damage = 1.6f;
            entity.knockbackForce = 1.2f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.95f;
            entity.canGetKnockedBack = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);
                
                if (randomAttackAnim == 0){
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleSwordsman_Attack_2",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleSwordsman_Attack_1",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleSwordsman_Attack_1",false);
                    gameObject.GetComponent<Entity>().animator.SetBool("DoubleSwordsman_Attack_2",true);
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding){
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleSwordsman_Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("DoubleSwordsman_Attack_2",false);
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
                opponentEntity.HP -= gameObject.GetComponent<Entity>().damage/2;

                Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * gameObject.GetComponent<Entity>().knockbackForce/3, ForceMode2D.Impulse);
                opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                StartCoroutine(gameObject.GetComponent<Entity>().StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
            }
        }
    }
}
