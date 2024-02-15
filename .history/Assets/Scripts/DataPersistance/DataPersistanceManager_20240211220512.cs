using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{

    private GameData gameData;

    public static DataPersistanceManager instance {get; private set;}

    private void Awake(){
        if (instance != null){
            Debug.LogError("Error");
        }
        instance = this;
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){

    }

    public void SaveGame(){

    }

}
