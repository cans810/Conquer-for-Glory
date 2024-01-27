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
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 2.9f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 2.5f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("SwordsMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 3.6f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 3.5f;
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
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 4.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Archer")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 3f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 2.2f;
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
                soldier.GetComponent<Entity>().timeToSummon = 5.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 5.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 5.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 5.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 5.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 5.5f;
            }
            else if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 5.5f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("DoubleSwordsMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 12f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Minotaur")){
            if (soldier.GetComponent<Entity>().race.Equals("Elf")){
                soldier.GetComponent<Entity>().timeToSummon = 29f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("KingsKnight")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 14f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("StormBringer")){
            if (soldier.GetComponent<Entity>().race.Equals("Human")){
                soldier.GetComponent<Entity>().timeToSummon = 22f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("DoubleEdgedBladeMan")){
            if (soldier.GetComponent<Entity>().race.Equals("Orc")){
                soldier.GetComponent<Entity>().timeToSummon = 12f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("SpearMaster")){
            if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 13f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Dragon")){
            if (soldier.GetComponent<Entity>().race.Equals("Demon")){
                soldier.GetComponent<Entity>().timeToSummon = 1f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("TrollGiant")){
            if (soldier.GetComponent<Entity>().race.Equals("Troll")){
                soldier.GetComponent<Entity>().timeToSummon = 26f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("EasternLion")){
            if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 19f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Warlord")){
            if (soldier.GetComponent<Entity>().race.Equals("EasternHuman")){
                soldier.GetComponent<Entity>().timeToSummon = 29f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("Mammoth")){
            if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 30f;
            }
        }
        if (soldier.GetComponent<Entity>().soldierType.Equals("WraithCaller")){
            if (soldier.GetComponent<Entity>().race.Equals("Wraith")){
                soldier.GetComponent<Entity>().timeToSummon = 28f;
            }
        }
    }
}
