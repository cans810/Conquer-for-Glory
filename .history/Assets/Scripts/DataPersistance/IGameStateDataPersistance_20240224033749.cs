using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateDataPersistance
{
    void LoadStateData(GameStateData data);
    void SaveStateData(ref GameStateData data);
}
