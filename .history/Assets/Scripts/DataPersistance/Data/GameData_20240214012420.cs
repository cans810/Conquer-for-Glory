using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<GameObject> PlayerSoldiers;
    public List<string> PlayerSoldierIdentifiers;
    public string PlayerRace;
    public Color playerLandColor;
    public int speedTrainingPoint;
    public int armourIncreasePoint;
    public int archeryPoint;

    public List<string> AllConqueredCityNames;
    public List<GameObject> AllNeighbours;
    public bool allLandsConquered;

    public int balance;

    public GameData(){
        this.PlayerSoldiers = new List<GameObject>();
        this.PlayerRace = "";
        this.playerLandColor = Color.white;
        this.speedTrainingPoint = 0;
        this.armourIncreasePoint = 0;
        this.archeryPoint = 0;

        this.AllConqueredCityNames = new List<string>();
        this.AllNeighbours = new List<GameObject>();
        this.allLandsConquered = false;

        this.balance = 0;
    }

}
