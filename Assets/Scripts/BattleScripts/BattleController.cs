using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    //public GameObject BattleGround;
    public GameObject PlayerSummonPoints;
    public GameObject PlayerSoldierContainers;
    public int currentSelectedSummonPoint;
    public int currentSelectedSoldierContainer;

    public int playerProgress;

    public bool playerWon;
    public bool playerLost;
    

    public void Awake(){
        Transform parentTransformSoldierContainers = PlayerSoldierContainers.transform;
        parentTransformSoldierContainers.gameObject.GetComponent<PlayerSideSoldierContainersManager>().initContainers();

        currentSelectedSummonPoint = 0;
        currentSelectedSoldierContainer = 0;

        Transform parentTransformSummonPoints = PlayerSummonPoints.transform;
        parentTransformSummonPoints.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = true;
        parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = true;

        playerProgress = 50;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // update soldier containers
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentSelectedSummonPoint-1 >= 0){
                Transform parentTransform = PlayerSummonPoints.transform;
                parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = false;

                currentSelectedSummonPoint--;
                
                parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentSelectedSummonPoint+1 <= 7){
                Transform parentTransform = PlayerSummonPoints.transform;
                parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = false;

                currentSelectedSummonPoint++;
                
                parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentSelectedSoldierContainer - 1 >= 0)
            {
                Transform parentTransform = PlayerSoldierContainers.transform;
                parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = false;

                currentSelectedSoldierContainer--;

                parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentSelectedSoldierContainer + 1 < GameManager.Instance.PlayerSoldiers.Count)
            {
                Transform parentTransform = PlayerSoldierContainers.transform;
                parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = false;

                currentSelectedSoldierContainer++;

                parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform parentTransform = PlayerSoldierContainers.transform;

            if (parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().canSummon){
                Transform transformSummonPoint = PlayerSummonPoints.transform;

                Transform summonPoint = transformSummonPoint.GetChild(currentSelectedSummonPoint);

                float summonPointHeight = summonPoint.GetComponent<Renderer>().bounds.size.y;

                Vector3 spawnPosition = summonPoint.position - new Vector3(0.5f, summonPointHeight / 2f, 0);

                GameObject playerSoldier = Instantiate(
                    parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().SoldierContained,
                    spawnPosition,
                    Quaternion.identity);

                playerSoldier.tag = "Player";
                playerSoldier.GetComponent<Entity>().direction = "right";
                playerSoldier.GetComponent<Entity>().spawnedAtRow = currentSelectedSummonPoint;

                // summonladıktan sonra hepsini resetle
                ResetPlayerSoldierContainers();
            }
        }

        if (playerWon){
            // you won window
            // give some coins
        }
        else if (playerLost){
            // every soldier run back + you lost window
            // dont give coins
        }

    }


    public void ResetPlayerSoldierContainers(){
        Transform parentTransformSoldierContainers = PlayerSoldierContainers.transform;

        foreach (Transform child in parentTransformSoldierContainers){
            child.gameObject.GetComponent<SoldierContainerManager>().timer = 0;
            child.gameObject.GetComponent<SoldierContainerManager>().canSummon = false;
        }
    }
}
