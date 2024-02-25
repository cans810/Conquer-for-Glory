using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarlordController : MonoBehaviour
{
    public bool playingAttackAnim;

    public int throwableSpearCount;
    public GameObject rangedHitbox;
    public GameObject throwableSpearPrefab;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("EasternHuman")){
            entity.HP = 32;
            entity.damage = 2.5f;
            entity.knockbackForce = 1.4f;
            entity.knockbackDuration = 0.13f;
            entity.speed = 0.87f;
            entity.canGetKnockedBack = false;
        }

        throwableSpearCount = 3;

        entity.canBurn = true;
        entity.canBeRipped = true;
        entity.canDarkMagicEffect = true;
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
                    gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack_2",true);
                }
            }
            else if (rangedHitbox.GetComponent<HitBoxController>().colliding && 
            rangedHitbox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim && !GetComponent<Entity>().burning && throwableSpearCount > 0){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                playingAttackAnim = true;
                gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack_3",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && !GetComponent<Entity>().burning){
                gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack_3",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack_2",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Warlord_Attack_3",false);
    }

    public void instantiateAndShootSpear(){
        Vector3 offset = new Vector3(0, 0.53f, 0f);
        GameObject throwableSpear = Instantiate(throwableSpearPrefab,transform.position,Quaternion.identity);
        throwableSpear.transform.position += offset;
        throwableSpear.GetComponent<ThrowableSpearController>().sourceEntity = gameObject;
        throwableSpearCount -= 1;
    }
}
