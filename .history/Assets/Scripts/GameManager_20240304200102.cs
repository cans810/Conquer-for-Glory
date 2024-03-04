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

    public GameData gameData;
    public GameData gameData;

    public void LoadData(GameData data)
    {
        this.playerSoldierIDs = data.playerSoldierIDs;
        this.PlayerRace = data.PlayerRace;
        this.playerLandColor = data.playerLandColor;
        this.speedTrainingPoint = data.speedTrainingPoint;
        this.armourIncreasePoint = data.armourIncreasePoint;
        this.archeryPoint = data.archeryPoint;

        this.AllConqueredCityNames = data.AllConqueredCityNames;
        this.AllNeighbours = data.AllNeighbours;
        this.allLandsConquered = data.allLandsConquered;

        this.DynamicDifficulty = data.DynamicDifficulty;

        this.balance = data.balance;
    }

    public void SaveData(ref GameData data)
    {
        data.playerSoldierIDs = this.playerSoldierIDs;
        data.PlayerRace = this.PlayerRace;
        data.playerLandColor = this.playerLandColor;
        data.speedTrainingPoint = this.speedTrainingPoint;
        data.armourIncreasePoint = this.armourIncreasePoint;
        data.archeryPoint = this.archeryPoint;

        data.AllConqueredCityNames = this.AllConqueredCityNames;
        data.AllNeighbours = this.AllNeighbours;
        data.allLandsConquered = this.allLandsConquered;

        data.DynamicDifficulty = this.DynamicDifficulty;

        data.balance = this.balance;
    }

    public void LoadStateData(GameStateData data)
    {
        this.finishedGameCtr = data.finishedGameCtr;
    }

    public void SaveStateData(ref GameStateData data)
    {
        data.finishedGameCtr = this.finishedGameCtr;
    }

    public void SaveGameButton(){
        DataPersistanceManager.instance.SaveGame();
        StartCoroutine(Settings.GetComponent<SettingsManager>().displaySavedText());
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
    }
}
