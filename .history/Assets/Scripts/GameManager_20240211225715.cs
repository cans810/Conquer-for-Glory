using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, IDataPersistance
{
    public static GameManager Instance;

    public List<GameObject> PlayerSoldiers;
    public string PlayerRace;
    public Color playerLandColor;
    public Dictionary<string, int> playerUpgradeMap;

    
    public string CurrentEnemyName;
    public string CurrentEnemyRace;
    public List<GameObject> CurrentEnemySoldiers;

    public List<string> AllConqueredCityNames;
    public List<GameObject> AllNeighbours;
    public bool allLandsConquered;

    public int balance;

    public void LoadData(GameData data)
    {
        this.PlayerSoldiers = data.PlayerSoldiers;
        this.PlayerRace = data.PlayerRace;
        this.playerLandColor = data.playerLandColor;
        this.playerUpgradeMap = data.playerUpgradeMap;
        this.playerUpgradeMap["Speed Training"] = data.playerUpgradeMap["Speed Training"];
        this.playerUpgradeMap["Armour Increase"] = data.playerUpgradeMap["Armour Increase"];
        this.playerUpgradeMap["Archery"] = data.playerUpgradeMap["Archery"];

        this.AllConqueredCityNames = data.AllConqueredCityNames;
        this.AllNeighbours = data.AllNeighbours;
        this.allLandsConquered = data.allLandsConquered;

        this.balance = data.balance;
    }

    public void SaveData(ref GameData data)
    {
        data.PlayerSoldiers = this.PlayerSoldiers;
        data.PlayerRace = this.PlayerRace;
        data.playerLandColor = this.playerLandColor;
        data.playerUpgradeMap = this.playerUpgradeMap;
        this.playerUpgradeMap["Speed Training"] = data.playerUpgradeMap["Speed Training"];
        this.playerUpgradeMap["Armour Increase"] = data.playerUpgradeMap["Armour Increase"];
        this.playerUpgradeMap["Archery"] = data.playerUpgradeMap["Archery"];

        data.AllConqueredCityNames = this.AllConqueredCityNames;
        data.AllNeighbours = this.AllNeighbours;
        data.allLandsConquered = this.allLandsConquered;

        data.balance = this.balance;
    }

    public void SaveGameButton(){
        DataPersistanceManager.instance.SaveGame();
    }

    public void LoadGameButton(){
        DataPersistanceManager.instance.LoadGame();
        SceneManager.LoadScene("MapScene");
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

        AllConqueredCityNames = new List<string>();
        AllNeighbours = new List<GameObject>();
        playerUpgradeMap = new Dictionary<string, int>();

        playerUpgradeMap.Add("Speed Training",0);
        playerUpgradeMap.Add("Armour Increase",0);
        playerUpgradeMap.Add("Archery",0);
    }
}
