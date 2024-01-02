using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordsManController : MonoBehaviour
{

    public bool playingAttackAnim;

    void Start(){
        GameObject entityObject = gameObject;
        Entity entity = entityObject.GetComponent<Entity>();

        if (entity.race.Equals("Human")){
            entity.HP = 8;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.66f;
        }
        else if (entity.race.Equals("Orc")){
            entity.HP = 7;
            entity.damage = 1.2f;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Troll")){
            entity.HP = 7;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Demon")){
            entity.HP = 7;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Elf")){
            entity.HP = 7.5f;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("EasternHuman")){
            entity.HP = 7.5f;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        else if (entity.race.Equals("Wraith")){
            entity.HP = 7.5f;
            entity.damage = 1;
            entity.knockbackForce = 1f;
            entity.knockbackDuration = 0.1f;
            entity.speed = 0.65f;
        }
        entity.canGetKnockedBack = true;
    }

    private bool attackDelayActive = false;

    void Update()
    {
        if (!GetComponent<Entity>().dead)
        {
            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding 
                && GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null 
                && !playingAttackAnim && !GetComponent<Entity>().gettingKnockedBack)
            {
                if (!attackDelayActive)
                {
                    StartCoroutine(TriggerAttackWithDelay());
                }
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim)
            {
                playingAttackAnim = false;
                ResetAttackAnimations();
                GetComponent<Entity>().animator.SetBool("Walk", true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction, GetComponent<Entity>().speed);
            }
        }
    }

    IEnumerator TriggerAttackWithDelay()
    {
        attackDelayActive = true;

        gameObject.GetComponent<Entity>().animator.SetBool("Walk", false);

        int randomAttackAnim = Random.Range(0, 2);

        if (randomAttackAnim == 0)
        {
            gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack", true);
        }
        else if (randomAttackAnim == 1)
        {
            gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack_2", true);
        }

        setAttackAnimPlaying();

        yield return new WaitForSeconds(0.1f); // Adjust the delay time as needed

        attackDelayActive = false;
    }

    void ResetAttackAnimations()
    {
        gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack", false);
        gameObject.GetComponent<Entity>().animator.SetBool("Swordsman_Attack_2", false);
    }


    public void setAttackAnimPlaying(){
        playingAttackAnim = true;
    }
    public void AttackAnimOver(){
        playingAttackAnim = false;
    }
}
