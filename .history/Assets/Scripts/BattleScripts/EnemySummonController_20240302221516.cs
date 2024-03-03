using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySummonController : MonoBehaviour
{
    public GameObject EnemySummonPoints;
    public GameObject EnemySoldierContainers;
    public int currentSelectedSummonPoint;
    public int currentSelectedSoldierContainer;

    Transform parentTransformSummonPoints;
    Transform parentTransformSoldierContainers;

    public bool chosenRandomSoldier;

    public void Awake(){
        currentSelectedSummonPoint = 0;
        currentSelectedSoldierContainer = 0;

        parentTransformSummonPoints = EnemySummonPoints.transform;
        parentTransformSoldierContainers = EnemySoldierContainers.transform;

        parentTransformSoldierContainers.gameObject.GetComponent<EnemySideSoldierContainersManager>().initContainers();
    }

    void Update()
    {
            if (!chosenRandomSoldier){
                chooseRandomSoldierToSummon();
            }

            if (parentTransformSoldierContainers != null){
                GameObject battlecontroller = GameObject.Find("BattleController");

                if (parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().canSummon && battlecontroller.GetComponent<BattleController>().playerDeathCounterUlti >= 20){
                    GameObject enemySoldier = null;

                    for (int i=0;i<8;i++){
                        Transform summonPoint = parentTransformSummonPoints.GetChild(i);

                        float summonPointHeight = summonPoint.GetComponent<Renderer>().bounds.size.y;

                        float randomXOffset = Random.Range(0f,0.2f);

                        Vector3 spawnPosition = summonPoint.position - new Vector3(-0.8f - randomXOffset, summonPointHeight / 3f, 0);

                        enemySoldier = Instantiate(
                            parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().SoldierContained,
                            spawnPosition,
                            Quaternion.identity);

                        enemySoldier.GetComponent<Entity>().gameObject.tag = "Enemy";
                        enemySoldier.GetComponent<EntityCommonActions>().ChangeDirection("left");
                        enemySoldier.GetComponent<Entity>().direction = "left";
                        enemySoldier.GetComponent<Entity>().spawnedAtRow = i;
                    }

                    if (enemySoldier.transform.Find("SoundManager")){
                       enemySoldier.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSummonSound();
                    }

                    // summonladıktan sonra hepsini resetle
                    ResetPlayerSoldierContainers();
                    chosenRandomSoldier = false;
                    battlecontroller.GetComponent<BattleController>().playerDeathCounterUlti = 0;
                }
                
                else if (parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().canSummon && battlecontroller.GetComponent<BattleController>().playerDeathCounterUlti < 20){
                    chooseRandomSummonPoint();

                    Transform summonPoint = parentTransformSummonPoints.GetChild(currentSelectedSummonPoint);

                    float summonPointHeight = summonPoint.GetComponent<Renderer>().bounds.size.y;

                    float randomXOffset = Random.Range(0f,0.2f);

                    Vector3 spawnPosition = summonPoint.position - new Vector3(-0.8f - randomXOffset, summonPointHeight / 3f, 0);

                    GameObject enemySoldier = Instantiate(
                        parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().SoldierContained,
                        spawnPosition,
                        Quaternion.identity);

                    enemySoldier.GetComponent<Entity>().gameObject.tag = "Enemy";
                    enemySoldier.GetComponent<EntityCommonActions>().ChangeDirection("left");
                    enemySoldier.GetComponent<Entity>().direction = "left";
                    enemySoldier.GetComponent<Entity>().spawnedAtRow = currentSelectedSummonPoint;

                    if (enemySoldier.transform.Find("SoundManager")){
                       enemySoldier.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSummonSound();
                    }

                    // summonladıktan sonra hepsini resetle
                    ResetPlayerSoldierContainers();
                    chosenRandomSoldier = false;
                }
            }
    }

    public void chooseRandomSoldierToSummon(){
        int soldierCount = 0;
        foreach (Transform child in parentTransformSoldierContainers)
        {
            soldierCount++;
        }

        int randomSoldier = UnityEngine.Random.Range(0, soldierCount);
        currentSelectedSoldierContainer = randomSoldier;

        chosenRandomSoldier = true;
    }

    public void chooseRandomSummonPoint(){
        int randomPoint = UnityEngine.Random.Range(0, 8);
        currentSelectedSummonPoint = randomPoint;
    }

    public void chooseSpecificSummonPoint(){
        // Find all GameObjects with the tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Debug.Log("Found player: " + player.name);
        }
    }

    public void ResetPlayerSoldierContainers(){
        Transform parentTransformSoldierContainers = EnemySoldierContainers.transform;

        foreach (Transform child in parentTransformSoldierContainers){
            child.gameObject.GetComponent<SoldierContainerManager>().timer = 0;
            child.gameObject.GetComponent<SoldierContainerManager>().canSummon = false;
        }
    }
}
