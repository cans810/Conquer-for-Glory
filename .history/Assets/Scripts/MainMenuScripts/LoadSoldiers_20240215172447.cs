using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoldiers : MonoBehaviour
{
    public List<GameObject> AllSoldiersInGame;
    
    public void LoadGame(){
        DataPersistanceManager.instance.LoadGame();


    }
}
