using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSoldiers : MonoBehaviour
{
    private void OnEnable() {
        DataPersistanceManager.instance.LoadGame();
    }
}
