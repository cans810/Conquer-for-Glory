using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<GameObject> PlayerSoldiers;
    public List<string> playerSoldierIDs;
    public string PlayerRace;
    public Color playerLandColor;

    public int speedTrainingPoint;
    public int armourIncreasePoint;
    public int archeryPoint;

    public string CurrentEnemyName;
    public string CurrentEnemyRace;
    public List<GameObject> CurrentEnemySoldiers;

    public List<string> AllConqueredCityNames;
    public List<GameObject> AllNeighbours;
    public bool allLandsConquered;

    public int DynamicDifficulty;

    public int balance;
    public GameObject Settings;

    public int finishedGameCtr;

    public GameData gameData = null;
    public GameStateData gameStateData = null;

    public void LoadGameData()
    {
        gameData = SaveSystem.Load();

        this.playerSoldierIDs = gameData.playerSoldierIDs;
        this.PlayerRace = gameData.PlayerRace;
        this.speedTrainingPoint = gameData.speedTrainingPoint;
        this.armourIncreasePoint = gameData.armourIncreasePoint;
        this.archeryPoint = gameData.archeryPoint;

        this.AllConqueredCityNames = gameData.AllConqueredCityNames;
        this.allLandsConquered = gameData.allLandsConquered;

        this.DynamicDifficulty = gameData.DynamicDifficulty;

        this.balance = gameData.balance;
    }

    public void SaveGameData(GameData data)
    {
        data.playerSoldierIDs = this.playerSoldierIDs;
        data.PlayerRace = this.PlayerRace;
        data.speedTrainingPoint = this.speedTrainingPoint;
        data.armourIncreasePoint = this.armourIncreasePoint;
        data.archeryPoint = this.archeryPoint;

        data.AllConqueredCityNames = this.AllConqueredCityNames;
        data.allLandsConquered = this.allLandsConquered;

        data.DynamicDifficulty = this.DynamicDifficulty;

        data.balance = this.balance;

        SaveSystem.Save(data);
    }

    public void SaveGameButton(){
        SaveGameData(gameData);

        StartCoroutine(Settings.GetComponent<SettingsManager>().displaySavedText());
    }

    public void LoadStateData()
    {
        gameStateData = SaveSystem.LoadGameState();

        this.finishedGameCtr = gameStateData.finishedGameCtr;
    }

    public void SaveStateData(GameStateData data)
    {
       data.finishedGameCtr = this.finishedGameCtr;

       SaveSystem.SaveGameState(data);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        PlayerSoldiers = new List<GameObject>();
        AllConqueredCityNames = new List<string>();
        AllNeighbours = new List<GameObject>();
    }

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 500;

        LoadStateData();
    }

    private void OnApplicationQuit()
    {
        SaveGameData(gameData);
        SaveStateData(gameStateData);
    }
}
