using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataPersistanceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;
    [SerializeField] private string statedatafileName;
    [SerializeField] private bool useEncryption;


    private GameData gameData;
    private GameStateData gameStateData;
    private List<IDataPersistance> dataPersistanceObjects;
    private List<IGameStateDataPersistance> gameStateDataPersistanceObjects;

    private FileDataHandler dataHandler;

    public static DataPersistanceManager instance {get; private set;}

    private void Awake(){
        if (instance != null){
            Debug.LogError("Error");
        }
        instance = this; 
    }

    private void Start(){
        this.dataHandler = new FileDataHandler(Application.persistentDataPath,fileName,Application.persistentDataPath,statedatafileName,useEncryption);

        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        this.gameStateDataPersistanceObjects = FindAllGameStateDataPersistanceObjects();
    }

    public void NewGame(){
        this.gameData = new GameData();
        LoadGameState();

        GameManager.Instance.PlayerSoldiers = new List<GameObject>();
        GameManager.Instance.playerSoldierIDs = new List<string>();
        GameManager.Instance.PlayerRace = "";
        GameManager.Instance.playerLandColor = Color.white;
        GameManager.Instance.speedTrainingPoint = 0;
        GameManager.Instance.armourIncreasePoint = 0;
        GameManager.Instance.archeryPoint = 0;

        GameManager.Instance.AllConqueredCityNames = new List<string>();
        GameManager.Instance.AllNeighbours = new List<GameObject>();
        GameManager.Instance.allLandsConquered = false;

        GameManager.Instance.DynamicDifficulty = 0;

        GameManager.Instance.balance = 0;
    }

    public void NewGameState(){
        this.gameStateData = new GameStateData();
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

        LoadGameState();
    }

    public void SaveGame(){

        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects){
            dataPersistanceObj.SaveData(ref gameData);
        }

        dataHandler.Save(gameData);
    }

    public void LoadGameState(){
        this.gameStateData = dataHandler.LoadGameState();

        if (this.gameStateData == null){
            NewGameState();
        }

        foreach(IGameStateDataPersistance dataPersistanceObj in gameStateDataPersistanceObjects){
            dataPersistanceObj.LoadStateData(gameStateData);
        }
    }

    public void SaveGameState(){
        foreach(IGameStateDataPersistance dataPersistanceObj in gameStateDataPersistanceObjects){
            dataPersistanceObj.SaveStateData(ref gameStateData);
        }

        dataHandler.SaveGameState(gameStateData);
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects(){
        IEnumerable<IDataPersistance> dataPersistanceObjects = 
        FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }

    private List<IGameStateDataPersistance> FindAllGameStateDataPersistanceObjects(){
        IEnumerable<IGameStateDataPersistance> gameStateDataPersistanceObjects = 
        FindObjectsOfType<MonoBehaviour>().OfType<IGameStateDataPersistance>();

        return new List<IGameStateDataPersistance>(gameStateDataPersistanceObjects);
    }

}
