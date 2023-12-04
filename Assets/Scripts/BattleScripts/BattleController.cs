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

    public void Awake(){
        currentSelectedSummonPoint = 0;
        currentSelectedSoldierContainer = 0;

        Transform parentTransformSummonPoints = PlayerSummonPoints.transform;
        parentTransformSummonPoints.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = true;

        Transform parentTransformSoldierContainers = PlayerSoldierContainers.transform;
        parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = true;

        foreach (Transform child in parentTransformSoldierContainers)
        {
            child.gameObject.GetComponent<SoldierContainerManager>().SoldierContained.GetComponent<Entity>().race = GameManager.Instance.PlayerRace;
            child.gameObject.GetComponent<SoldierContainerManager>().SoldierContained.GetComponent<Entity>().summonedByPlayer = true;
            SetSummonTimers(child.gameObject.GetComponent<SoldierContainerManager>().SoldierContained);
        }
        

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

                // summonladıktan sonra hepsini resetle
                ResetPlayerSoldierContainers();
            }
        }

    }


    public void ResetPlayerSoldierContainers(){
        Transform parentTransformSoldierContainers = PlayerSoldierContainers.transform;

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
        else if (soldier.GetComponent<Entity>().soldierType.Equals("AxeMan")){
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
        else if (soldier.GetComponent<Entity>().soldierType.Equals("MountedSpearman")){
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
        else if (soldier.GetComponent<Entity>().soldierType.Equals("MountedSwordsman")){
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
