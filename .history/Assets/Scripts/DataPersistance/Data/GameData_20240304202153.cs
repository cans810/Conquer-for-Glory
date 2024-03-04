using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<string> playerSoldierIDs;
    public string PlayerRace;
    //public Color playerLandColor;
    public int speedTrainingPoint;
    public int armourIncreasePoint;
    public int archeryPoint;

    public List<string> AllConqueredCityNames;
    public bool allLandsConquered;

    public int DynamicDifficulty;

    public int balance;

    public GameData(){
        this.playerSoldierIDs = new List<string>();
        this.PlayerRace = "";
        //this.playerLandColor = Color.white;
        this.speedTrainingPoint = 0;
        this.armourIncreasePoint = 0;
        this.archeryPoint = 0;

        this.AllConqueredCityNames = new List<string>();
        //this.AllNeighbours = new List<GameObject>();
        this.allLandsConquered = false;

        this.DynamicDifficulty = 0;

        this.balance = 0;
    }

}
