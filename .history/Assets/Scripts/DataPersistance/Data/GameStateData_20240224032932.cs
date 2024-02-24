using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStateData
{

    public bool DemonUnlocked;
    public bool WraithUnlocked;
    public int finishedGameCtr;
    
    public void GameStateData(){
    this.DemonUnlocked = false;
    this.WraithUnlocked = false;
    this.finishedGameCtr = 0;
    }
}
