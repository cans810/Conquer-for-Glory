using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public bool playingMeleeAttackAnim;
    public bool playingFireAttackAnim;

    public GameObject fireHitbox;
    public GameObject firePilePrefab;

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
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingMeleeAttackAnim){
                int randomAttack = UnityEngine.Random.Range(0,1);

                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",false);

                playingMeleeAttackAnim = true;

                if (randomAttack == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
                    gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",true);
                }
            }
            else if (fireHitbox.GetComponent<DragonFireHitBoxController>().colliding && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents.Count > 0 
            && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents != null && !playingFireAttackAnim && !playingMeleeAttackAnim){

                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",false);

                playingFireAttackAnim = true;

                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !fireHitbox.GetComponent<DragonFireHitBoxController>().colliding && !playingFireAttackAnim && !playingMeleeAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",false);
                //gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Fly",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void fireDamageOpponents()
    {
        if (fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents.Count > 0 && fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents != null)
        {
            foreach (GameObject enemy in fireHitbox.GetComponent<DragonFireHitBoxController>().currentHittingOpponents){

                Entity opponentEntity = enemy.GetComponent<Entity>();

                if (opponentEntity != null)
                {
                    opponentEntity.HP -= GetComponent<Entity>().damage;
                }
            }
        }
    }

    public void stopAttackAnim(){
        playingMeleeAttackAnim = false;

        gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack",false);
        //gameObject.GetComponent<Entity>().animator.SetBool("Dragon_Attack_2",false);
    }

    public void playStepSound(){
        //gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(0);
    }

    public void playDeathSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(4);
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
