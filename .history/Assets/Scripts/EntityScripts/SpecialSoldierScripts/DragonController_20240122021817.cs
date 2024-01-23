using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public bool playingAttackAnim;

    public GameObject fireHitbox;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Demon")){
            entity.HP = 60;
            entity.damage = 5f;
            entity.knockbackForce = 3f;
            entity.knockbackDuration = 0.18f;
            entity.speed = 0.67f;

            entity.canGetKnockedBack = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Entity>().dead){
            // melee attack
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,1);

                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",false);

                playingAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
                    gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",true);
                }
            }
            else if (fireHitbox.GetComponent<DragonFireHitBoxController>().colliding && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents.Count > 0 && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",false);

                playingAttackAnim = true;

                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",false);
                //gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void damageOpponentMelee()
    {
        if (fireHitbox.GetComponent<HitBoxController>().currentHittingOpponent != null)
        {
            Entity opponentEntity = fireHitbox.GetComponent<HitBoxController>().currentHittingOpponent.GetComponent<Entity>();
            
            if (opponentEntity != null)
            {
                opponentEntity.HP -= GetComponent<Entity>().damage;
                if (opponentEntity.canGetKnockedBack){
                    Vector2 direction = (opponentEntity.transform.position - transform.position).normalized;

                    opponentEntity.GetComponent<Rigidbody2D>().AddForce(direction * GetComponent<Entity>().knockbackForce, ForceMode2D.Impulse);
                    opponentEntity.GetComponent<Entity>().gettingKnockedBack = true;

                    StartCoroutine(GetComponent<Entity>().StopKnockback(opponentEntity.GetComponent<Rigidbody2D>()));
                }
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",false);
        //gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",false);
    }

    public void playStepSound(){
        //gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(0);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
    }
}
