using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
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
                if (parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().canSummon){
                    chooseRandomSummonPoint();

                    Transform summonPoint = parentTransformSummonPoints.GetChild(currentSelectedSummonPoint);

                    float summonPointHeight = summonPoint.GetComponent<Renderer>().bounds.size.y;

                    Vector3 spawnPosition = summonPoint.position - new Vector3(-0.5f, summonPointHeight / 2f, 0);

                    GameObject enemySoldier = Instantiate(
                        parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().SoldierContained,
                        spawnPosition,
                        Quaternion.identity);

                    enemySoldier.GetComponent<Entity>().gameObject.tag = "Enemy";
                    enemySoldier.GetComponent<EntityCommonActions>().ChangeDirection("left");
                    enemySoldier.GetComponent<Entity>().direction = "left";

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

    public void ResetPlayerSoldierContainers(){
        Transform parentTransformSoldierContainers = EnemySoldierContainers.transform;

        foreach (Transform child in parentTransformSoldierContainers){
            child.gameObject.GetComponent<SoldierContainerManager>().timer = 0;
            child.gameObject.GetComponent<SoldierContainerManager>().canSummon = false;
        }
    }
}
