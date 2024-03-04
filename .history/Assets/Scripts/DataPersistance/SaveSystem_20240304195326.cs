using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(GameData data){
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Create);
        formatter.Serialize(fs,data);
        fs.Close();
    }

    public static GameData Load(){
        BinaryFormatter formatter =  new BinaryFormatter();
        FileStream fs = new FileStream(GetPath(), FileMode.Open);
    }

    private static string GetPath(){
        return Application.persistentDataPath + "/data.qnd";
    }
}
