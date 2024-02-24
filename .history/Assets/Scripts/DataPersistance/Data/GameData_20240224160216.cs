using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<string> playerSoldierIDs;
    public string PlayerRace;
    public Color playerLandColor;
    public int speedTrainingPoint;
    public int armourIncreasePoint;
    public int archeryPoint;

    public List<string> AllConqueredCityNames;
    public List<GameObject> AllNeighbours;
    public bool allLandsConquered;

    public int DynamicDifficulty;

    public int balance;

    public GameData(){
        this.playerSoldierIDs = new List<string>();
        this.PlayerRace = "";
        this.playerLandColor = Color.white;
        this.speedTrainingPoint = 0;
        this.armourIncreasePoint = 0;
        this.archeryPoint = 0;

        this.AllConqueredCityNames = new List<string>();
        this.AllNeighbours = new List<GameObject>();
        this.allLandsConquered = false;

        this.DynamicDifficulty = 0;

        this.balance = 0;

        GameManager.Instance.PlayerSoldiers = new List<GameObject>();
        GameManager.Instance.playerSoldierIDs = new List<string>();
        GameManager.Instance.PlayerRace = "";
        GameManager.Instance.playerLandColor = Color.white;
        GameManager.Instance.speedTrainingPoint = 0;
        GameManager.Instance.armourIncreasePoint = 0;
        // GameManager.Instance.archeryPoint = 0;

        // GameManager.Instance.AllConqueredCityNames = new List<string>();
        // GameManager.Instance.AllNeighbours = new List<GameObject>();
        // GameManager.Instance.allLandsConquered = false;

        // GameManager.Instance.DynamicDifficulty = 0;

        // GameManager.Instance.balance = 0;
    }

}
