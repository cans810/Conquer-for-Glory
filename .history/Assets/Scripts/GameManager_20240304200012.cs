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

    public void SaveGameButton(){
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
