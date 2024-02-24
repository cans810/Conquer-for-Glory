using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateDataPersistance
{
    void LoadData(GameStateData data);
    void SaveData(ref GameData data);
}
