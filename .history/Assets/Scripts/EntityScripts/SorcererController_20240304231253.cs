using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorcererController : MonoBehaviour
{

    public GameObject magicBulbPrefab;
    public GameObject sorcererArm;

    public bool isWalking;
    public bool isSpelling;
    Entity entity;

    public void Start(){
        entity = entity;

        if (entity.race.Equals("Human")){
            entity.HP = 2.5f;
            entity.damage = 1.5f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 2.5f;
            entity.damage = 1.5f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 2.5f;
            entity.damage = 1.5f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.87f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 2.5f;
            entity.damage = 1.5f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 2.5f;
            entity.damage = 1.5f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 2.5f;
            entity.damage = 1.5f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.8f;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 3f;
            entity.damage = 2.1f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.89f;
        }
        else if (entity.race.Equals("SeaElf")){
            entity.HP = 3f;
            entity.damage = 2.1f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.2f;
            entity.speed = 0.89f;
        }

        isWalking = true;
        entity.canGetKnockedBack = true;
        entity.canBurn = true;
        entity.canBeRipped = true;
        entity.canDarkMagicEffect = true;
    }

    void Update()
    {
        if (!entity.dead){

            if (entity.HitBox.GetComponent<HitBoxController>().colliding && entity.HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !isSpelling && !entity.burning
            && !entity.gettingDarkMagicEffect){
                isSpelling = true;
                entity.animator.SetBool("Sorcerer_Attack",true);
                entity.animator.SetBool("Walk", false);
            }
            else if (!entity.HitBox.GetComponent<HitBoxController>().colliding && !entity.gettingKnockedBack && !isSpelling && !entity.burning
            && !entity.gettingDarkMagicEffect){

                entity.animator.SetBool("Sorcerer_Attack",false);
                entity.animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(entity.direction,entity.speed);

            }
        }
    }

    public void InstantiateAndShootMagicBulb()
    {
        float yOffset = -0.2f;
        Vector3 spawnPosition = sorcererArm.transform.position + new Vector3(0f, yOffset, 0f);

        GameObject magicBulbObject = Instantiate(magicBulbPrefab, spawnPosition, sorcererArm.transform.rotation);
        magicBulbObject.GetComponent<MagicBulbController>().sourceEntity = gameObject;

        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playMagicSound(0);
    }

    public void magicSpellEnded(){
        isSpelling = false;
    }

}
