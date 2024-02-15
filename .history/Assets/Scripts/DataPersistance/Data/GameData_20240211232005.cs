using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<GameObject> PlayerSoldiers;
    public string PlayerRace;
    public Color playerLandColor;
    public Dictionary<string, int> playerUpgradeMap;

    public List<string> AllConqueredCityNames;
    public List<GameObject> AllNeighbours;
    public bool allLandsConquered;

    public int balance;

    public GameData(){
        this.PlayerSoldiers = null;
        this.PlayerRace = "";
        this.playerLandColor = Color.white;

        this.AllConqueredCityNames = null;
        this.AllNeighbours = null;
        this.allLandsConquered = false;

        this.balance = 0;
    }

}
