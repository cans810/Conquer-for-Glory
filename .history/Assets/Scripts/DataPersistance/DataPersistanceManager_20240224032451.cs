using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private bool useEncryption;


    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistanceManager instance {get; private set;}

    private void Awake(){
        if (instance != null){
            Debug.LogError("Error");
        }
        instance = this; 
    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath,fileName,useEncryption);

        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
    }

    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){

        this.gameData = dataHandler.Load();

        if (this.gameData == null){
            SceneManager.LoadScene("RaceSelectionScene");
            NewGame();
        }

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects){
            dataPersistanceObj.LoadData(gameData);
        }
    }

    public void SaveGame(){

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects){
            dataPersistanceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    public void LoadGameState(){

    }

    public void SaveGameState(){
        
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects(){
        IEnumerable<IDataPersistance> dataPersistanceObjects = 
        FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }

}
