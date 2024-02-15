using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoldiers : MonoBehaviour
{
    public void Awake(){
        DataPersistanceManager.instance.LoadGame();
    }
}
