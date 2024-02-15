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

    public void LoadData()
    {
        this.PlayerRace = data.PlayerRace;
    }

    public void SaveData(ref GameData data)
    {
        data.PlayerRace = this.PlayerRace;
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
        playerUpgradeMap.Add("Spear Training",0);
        playerUpgradeMap.Add("Sword Training",0);
    }
}
