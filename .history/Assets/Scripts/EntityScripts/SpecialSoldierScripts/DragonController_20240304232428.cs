using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public bool playingMeleeAttackAnim;
    public bool playingFireAttackAnim;

    public GameObject fireHitbox;
    public GameObject firePilePrefab;

    public bool fireAttackDone;

    Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        if (entity.race.Equals("Demon")){
            entity.HP = 50;
            entity.damage = 5f;
            entity.knockbackForce = 3f;
            entity.knockbackDuration = 0.18f;
            entity.speed = 0.67f;

            entity.canGetKnockedBack = false;
        }
        fireAttackDone = false;

        entity.canBurn = false;
        entity.canBeRipped = false;
        entity.canDarkMagicEffect = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!entity.dead){
            // melee attack
            if (entity.HitBox.GetComponent<HitBoxController>().colliding && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingMeleeAttackAnim && !playingFireAttackAnim && fireAttackDone){
                int randomAttack = UnityEngine.Random.Range(0,1);

                entity.animator.SetBool("Dragon_Fly",false);

                playingMeleeAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(5);
                    entity.animator.SetBool("Dragon_Attack_2",true);
                }
            }
            else if (fireHitbox && fireHitbox.GetComponent<DragonFireHitBoxController>().colliding && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents.Count > 0 
            && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents != null && !playingFireAttackAnim && !playingMeleeAttackAnim && !fireAttackDone){

                entity.animator.SetBool("Dragon_Fly",false);

                playingFireAttackAnim = true;

                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(6);
                entity.animator.SetBool("Dragon_Attack",true);
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !fireHitbox.GetComponent<DragonFireHitBoxController>().colliding && !playingFireAttackAnim && !playingMeleeAttackAnim){
                entity.animator.SetBool("Dragon_Attack",false);
                entity.animator.SetBool("Dragon_Attack_2",false);
                entity.animator.SetBool("Dragon_Fly",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }

            if (playingFireAttackAnim){
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingMeleeAttackAnim = false;
        entity.animator.SetBool("Dragon_Attack_2",false);
    }

    public void fireAttackOver(){
        fireAttackDone = true;
        playingFireAttackAnim = false;
        entity.animator.SetBool("Dragon_Attack",false);
        fireHitbox.SetActive(false);
    }

    public void playStepSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(2);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(5);
    }

    public void createFirePile()
    {   
        float xOffset = 3.0f;
        float yOffset = 0.4f;
        Vector3 newPosition;

        if (entity.direction == "right"){
            newPosition = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
        }
        else{
            newPosition = new Vector3(transform.position.x - xOffset, transform.position.y + yOffset, transform.position.z);
        }

        GameObject firePile = Instantiate(firePilePrefab, newPosition, Quaternion.identity);
        firePile.GetComponent<FirePileController>().entity = gameObject;
    }
}
