using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(GameData data){
        string patyh = Application.persistentDataPath + "/data.qnd";
        BinaryFormatter formatter = new BinaryFormatter()
    }
}
