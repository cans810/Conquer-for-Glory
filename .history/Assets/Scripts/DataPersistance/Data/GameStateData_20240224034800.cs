using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameStateData
{
    public int finishedGameCtr;
    
    public GameStateData(){
        this.finishedGameCtr = 0;
    }
}
