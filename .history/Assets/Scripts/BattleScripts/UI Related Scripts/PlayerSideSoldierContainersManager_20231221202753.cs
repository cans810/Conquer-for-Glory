using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSideSoldierContainersManager : MonoBehaviour
{
    public GameObject SoldierContainerPrefab;

    public void Awake(){
    }

    public void initContainers(){
        foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

            GameObject SoldierContainer = GameObject.Instantiate(SoldierContainerPrefab);
            SoldierContainer.transform.SetParent(gameObject.transform);
            SoldierContainer.transform.localScale = new Vector3(0.75f,0.75f,0.75f);

            SoldierContainer.GetComponent<SoldierContainerManager>().SoldierContained = soldier;
            SetSummonTimers(SoldierContainer.GetComponent<SoldierContainerManager>().SoldierContained);
        }
    }

    public void SetSummonTimers(GameObject soldier){
        if (soldier.GetComponent<Entity>().soldierType.Equals("SpearMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 2.8f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("SwordsMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 3.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 3.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 3.2f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Archer")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.35f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 2.35f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("AxeMan")){
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
        if (soldier.GetComponent<Entity>().soldierType.Equals("MountedSpearman")){
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
        if (soldier.GetComponent<Entity>().soldierType.Equals("MountedSwordsman")){
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
        if (soldier.GetComponent<Entity>().soldierType.Equals("HatchetMan")){
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
        if (soldier.GetComponent<Entity>().soldierType.Equals("Sorcerer")){
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
        if (soldier.GetComponent<Entity>().soldierType.Equals("DoubleSwordsMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 10f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("KingsKnight")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 12f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("DoubleEdgedBladeMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 10.7f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("SpearMaster")){
            if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 12.5f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("TrollGiant")){
            if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 26f;
            }
        }
    }
    
}
