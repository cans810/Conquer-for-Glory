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

    public void Awake(){
        currentSelectedSummonPoint = 0;
        currentSelectedSoldierContainer = 0;

        parentTransformSummonPoints = EnemySummonPoints.transform;
        parentTransformSoldierContainers = EnemySoldierContainers.transform;

        foreach (Transform child in parentTransformSoldierContainers)
        {
            child.gameObject.GetComponent<SoldierContainerManager>().SoldierContained.GetComponent<Entity>().race = GameManager.Instance.CurrentEnemyRace;
            SetSummonTimers(child.gameObject);
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private bool hasSummoned = false;

    void Update()
    {
        // if (!hasSummoned)
        // {
            chooseRandomSoldierToSummon();
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

                    enemySoldier.GetComponent<Entity>().race = GameManager.Instance.CurrentEnemyRace;    
                    enemySoldier.GetComponent<Entity>().gameObject.tag = "Enemy";
                    //enemySoldier.GetComponent<Entity>().gameObject.layer = 7;
                    enemySoldier.GetComponent<EntityCommonActions>().ChangeDirection("left");
                    enemySoldier.GetComponent<Entity>().direction = "left";

                    // Set the flag to true to indicate that summoning has occurred
                    hasSummoned = true;

                    // summonladıktan sonra hepsini resetle
                    ResetPlayerSoldierContainers();
                }
            // }
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

    public void SetSummonTimers(GameObject soldier){
        if (soldier.GetComponent<Entity>().soldierType.Equals("SpearMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 2.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 2.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 2.3f;
            }
        }
        else if (soldier.GetComponent<Entity>().soldierType.Equals("SwordsMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
        }
        else if (soldier.GetComponent<Entity>().soldierType.Equals("Archer")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 2.1f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.1f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.1f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 2.1f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 2.1f;
            }
        }
    }
}
