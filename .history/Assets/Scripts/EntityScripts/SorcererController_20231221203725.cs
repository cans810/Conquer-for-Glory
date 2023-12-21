using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererController : MonoBehaviour
{

    public GameObject magicBulbPrefab;
    public GameObject sorcererArm;

    public bool isWalking;
    public bool isSpelling;

    public void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 5;
            entity.damage = 1.3f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 6;
            entity.damage = 1.3f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 5;
            entity.damage = 1.3f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 6;
            entity.damage = 1.3f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 4;
            entity.damage = 1.3f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }

        isWalking = true;
        entity.canGetKnockedBack = true;
    }

    void Update()
    {
        if (!gameObject.GetComponent<Entity>().dead){

            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !isSpelling){
                isSpelling = true;
                gameObject.GetComponent<Entity>().animator.SetBool("Sorcerer_Attack",true);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk", false);
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !GetComponent<Entity>().gettingKnockedBack && !isSpelling){

                gameObject.GetComponent<Entity>().animator.SetBool("Sorcerer_Attack",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);

            }
        }
    }

    public void InstantiateAndShootMagicBulb()
    {
        float yOffset = -0.5f; // Adjust this value to change the offset
        Vector3 spawnPosition = sorcererArm.transform.position + new Vector3(0f, yOffset, 0f);

        GameObject magicBulbObject = Instantiate(magicBulbPrefab, spawnPosition, sorcererArm.transform.rotation);
        magicBulbObject.GetComponent<MagicBulbController>().sourceEntity = gameObject;
    }

    public void magicSpellEnded(){
        isSpelling = false;
    }

}
