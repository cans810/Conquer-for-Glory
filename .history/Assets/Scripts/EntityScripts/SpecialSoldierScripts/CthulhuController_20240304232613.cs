using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthulhuController : MonoBehaviour
{

    public bool playingAttackAnim;

    public GameObject rangedHitBox;

    public int darkMagicCount;
    public bool canUseDarkMagic;

    public GameObject foundEnemy;

    bool searchingEnemy;
    public GameObject darkMagicPrefab;

Entity entity;

    public void Start(){
        entity = gameObject.GetComponent<Entity>();

        // only for elfs
        if (entity.race.Equals("SeaElf")){
            entity.HP = 55;
            entity.damage = 5.5f;
            entity.knockbackForce = 1.9f;
            entity.knockbackDuration = 0.18f;
            entity.speed = 0.55f;
            entity.canGetKnockedBack = false;
        }

        darkMagicCount = 6;

        entity.canBurn = false;
        entity.canBeRipped = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (!GetComponent<Entity>().dead){
            if (!searchingEnemy && darkMagicCount > 0 && !GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding){
                StartCoroutine(ResetSummonTimer()); 
            }

            if (GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && 
            GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().currentHittingOpponent != null && !playingAttackAnim){

                gameObject.GetComponent<Entity>().animator.SetBool("Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                int randomAttackAnim = Random.Range(0,2);

                playingAttackAnim = true;
                
                if (randomAttackAnim == 0){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                    gameObject.GetComponent<Entity>().animator.SetBool("Attack_2",true);
                }
                else if (randomAttackAnim == 1){
                    gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(1);
                    gameObject.GetComponent<Entity>().animator.SetBool("Attack_3",true);
                }
            }
            else if(!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !rangedHitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim && canUseDarkMagic && darkMagicCount > 0 && foundEnemy != null && !foundEnemy.GetComponent<Entity>().dead){
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",false);

                gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSpecialSoldierSound(7);
                darkMagicController();
            }
            else if (!GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding && !playingAttackAnim){
                gameObject.GetComponent<Entity>().animator.SetBool("Attack_1",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Attack_2",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Attack_3",false);
                gameObject.GetComponent<Entity>().animator.SetBool("Walk",true);
                GetComponent<EntityCommonActions>().walk(GetComponent<Entity>().direction,GetComponent<Entity>().speed);
            }
        }
    }

    public void stopAttackAnim(){
        playingAttackAnim = false;
        gameObject.GetComponent<Entity>().animator.SetBool("Attack_1",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Attack_2",false);
        gameObject.GetComponent<Entity>().animator.SetBool("Attack_3",false);
    }

    public void darkMagicController(){
        if (foundEnemy == null || foundEnemy.GetComponent<Entity>().dead){

        }
        else{
            playingAttackAnim = true;
            gameObject.GetComponent<Entity>().animator.SetBool("Attack_1",true);
            canUseDarkMagic = false;
        }
    }

    public void useDarkMagicOnEnemy(){
        summonDarkMagic();

        canUseDarkMagic = false;
        foundEnemy = null;
        darkMagicCount -= 1;
    }

    public void summonDarkMagic(){
        GameObject darkMagic = Instantiate(darkMagicPrefab,foundEnemy.transform.position,Quaternion.identity);
        darkMagic.GetComponent<DarkMagicController>().onEntity = foundEnemy;
        darkMagic.transform.SetParent(foundEnemy.transform);
    }

    public GameObject searchForEnemys(){

        if (tag.Equals("Player")){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, enemies.Length);

                GameObject randomEnemy = enemies[randomIndex];

                foundEnemy = randomEnemy;

                if (!foundEnemy.GetComponent<Entity>().canDarkMagicEffect && !foundEnemy.GetComponent<Entity>().dead && !foundEnemy.GetComponent<Entity>().gettingDarkMagicEffect){
                    searchForEnemys();
                }

                return randomEnemy;
            }
            else
            {
                foundEnemy = null;
                return null;
            }
        }
        else if (tag.Equals("Enemy")){
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player");

            if (enemies.Length > 0)
            {
                int randomIndex = Random.Range(0, enemies.Length);

                GameObject randomEnemy = enemies[randomIndex];

                foundEnemy = randomEnemy;

                if (!foundEnemy.GetComponent<Entity>().canDarkMagicEffect && !foundEnemy.GetComponent<Entity>().dead && !foundEnemy.GetComponent<Entity>().gettingDarkMagicEffect){
                    searchForEnemys();
                }

                return randomEnemy;
            }
            else
            {
                foundEnemy = null;
                return null;
            }
        }
        else{
            foundEnemy = null;
            return null;
        }
    }

    private IEnumerator ResetSummonTimer()
    {
        searchingEnemy = true;

        if (darkMagicCount > 0 && searchForEnemys() != null && !foundEnemy.GetComponent<Entity>().dead && !GetComponent<Entity>().HitBox.GetComponent<HitBoxController>().colliding){
            canUseDarkMagic = true;
        }
        else{
            canUseDarkMagic = false;
        }

        yield return new WaitForSeconds(3f);

        searchingEnemy = false;
    }

    public void playStepSound(){
        gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playGroundSound(0);
    }
}
