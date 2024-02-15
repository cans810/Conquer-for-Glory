using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoldiers : MonoBehaviour
{
    public List<GameObject> AllSoldiersInGame;

    public void LoadGame(){
        DataPersistanceManager.instance.LoadGame();

        foreach (GameObject soldier in AllSoldiersInGame){
            foreach(string soldierID in GameManager.Instance.playerSoldierIDs){
                if (soldier.GetComponent<Entity>().soldierID.Equals(soldierID)){
                    GameManager.Instance.PlayerSoldiers.Add(soldier);
                }
            }
        }
    }
}
