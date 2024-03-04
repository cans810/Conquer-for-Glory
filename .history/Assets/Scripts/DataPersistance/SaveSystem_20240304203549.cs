using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void Save(GameData data){
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetGameDataPath(), FileMode.Create);
        formatter.Serialize(fs,data);
        fs.Close();
    }

    public static GameData Load(){

        if (!File.Exists(GetGameDataPath())){
            GameData emptyData = new GameData();
            Save(emptyData);

            return emptyData;
        }

        BinaryFormatter formatter =  new BinaryFormatter();
        FileStream fs = new FileStream(GetGameDataPath(), FileMode.Open);
        GameData data = formatter.Deserialize(fs) as GameData;
        fs.Close();

        return data;
    }

    public static void SaveGameState(GameStateData data){
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream fs = new FileStream(GetGameStateDataPath(), FileMode.Create);
        formatter.Serialize(fs,data);
        fs.Close();
    }

    public static GameStateData LoadGameState(){

        if (!File.Exists(GetGameStateDataPath())){
            GameStateData emptyData = new GameStateData();
            SaveGameState(emptyData);

            return emptyData;
        }

        BinaryFormatter formatter =  new BinaryFormatter();
        FileStream fs = new FileStream(GetGameStateDataPath(), FileMode.Open);
        GameStateData data = formatter.Deserialize(fs) as GameStateData;
        fs.Close();

        return data;
    }

    public static GameData NewGameData(){
        GameData emptyData = new GameData();

        return emptyData;
    }

    public static bool hasAGameData(){
        if (!File.Exists(GetGameDataPath())){
            return true;
        }
        return false;
    }
    public static bool hasAGameStateData(){
        if (!File.Exists(GetGameStateDataPath())){
            return true;
        }
        return false;
    }

    private static string GetGameDataPath(){
        return Application.persistentDataPath + "/data.qnd";
    }
    private static string GetGameStateDataPath(){
        return Application.persistentDataPath + "/statedata.qnd";
    }
}
