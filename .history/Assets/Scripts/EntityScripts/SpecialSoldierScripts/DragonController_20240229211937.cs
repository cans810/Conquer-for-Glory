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

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

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
        if (!GetComponent<Entity>().dead){
            // melee attack
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
            && !playingMeleeAttackAnim && !playingFireAttackAnim && fireAttackDone){
                int randomAttack = UnityEngine.Random.Range(0,1);

                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",false);

                playingMeleeAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(5);
                    gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",true);
                }
            }
            else if (fireHitbox && fireHitbox.GetComponent<DragonFireHitBoxController>().colliding && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents.Count > 0 
            && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents != null && !playingFireAttackAnim && !playingMeleeAttackAnim && !fireAttackDone){

                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",false);

                playingFireAttackAnim = true;

                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(6);
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",true);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !fireHitbox.GetComponent<DragonFireHitBoxController>().colliding && !playingFireAttackAnim && !playingMeleeAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }

            if (playingFireAttackAnim){
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingMeleeAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",false);
    }

    public void fireAttackOver(){
        fireAttackDone = true;
        playingFireAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",false);
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

        if (GetComponent<Entity>().direction == "right"){
            newPosition = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, transform.position.z);
        }
        else{
            newPosition = new Vector3(transform.position.x - xOffset, transform.position.y + yOffset, transform.position.z);
        }

        GameObject firePile = Instantiate(firePilePrefab, newPosition, Quaternion.identity);
        firePile.GetComponent<FirePileController>().entity = gameObject;
    }
}
