using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateDataPersistance
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
