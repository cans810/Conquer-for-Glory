using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySideSoldierContainersManager : MonoBehaviour
{
    public GameObject SoldierContainerPrefab;


    public void initContainers(){
        foreach (GameObject soldier in GameManager.Instance.CurrentEnemySoldiers){

            GameObject SoldierContainer = GameObject.Instantiate(SoldierContainerPrefab);
            SoldierContainer.transform.SetParent(gameObject.transform);
            SoldierContainer.transform.localScale = new Vector3(0.75f,0.75f,0.75f);

            SoldierContainer.GetComponent<SoldierContainerManager>().SoldierContained = soldier;
            SetSummonTimers(SoldierContainer.GetComponent<SoldierContainerManager>().SoldierContained);
            SoldierContainer.GetComponent<SoldierIconCreator>().GenerateIconEnemySide();
        }
    }

    public void SetSummonTimers(GameObject soldier){
        if (soldier.GetComponent<Entity>().soldierType.Equals("SpearMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 2.7f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.7f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.7f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 3.1f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 2.7f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 2.7f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 2.7f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("SwordsMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 3.8f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 3.7f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 3.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 3.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 3.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 3.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 3.2f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Archer")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 2.4f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.4f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.4f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 2.4f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 3.0f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 2.4f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 2.4f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("AxeMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 4.8f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 5.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 4.8f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 4.8f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 4.8f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 4.8f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 4.8f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("MountedSpearman")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 6.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 6.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 6.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 6.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 6.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 6.3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 6.3f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("HatchetMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 4.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 4.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 4.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 4.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 4.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 4.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 4.6f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Sorcerer")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 5.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 5.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 5.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 5.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 5.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 5.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 5.9f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("DualBladeChampion")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 11f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Minotaur")){
            if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 20f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("QueensKnight")){
            if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 13f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("StormBringer")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 20f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("DoubleSidedRavager")){
            if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 11f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("OrcBeast")){
            if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 22f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("SpearMaster")){
            if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 13f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Dragon")){
            if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 29f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Darklord")){
            if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 17f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("TrollGiant")){
            if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 21f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("EasternLion")){
            if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 15f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Warlord")){
            if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 22f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Mammoth")){
            if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 24f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("WraithCaller")){
            if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 27f;
            }
        }
    }
}
