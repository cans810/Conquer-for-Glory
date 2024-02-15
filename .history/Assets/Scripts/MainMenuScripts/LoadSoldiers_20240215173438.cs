using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSoldiers : MonoBehaviour
{
    public List<GameObject> AllSoldiersInGame;

    public void LoadGame(){
        DataPersistanceManager.instance.LoadGame();

        Dictionary<string, GameObject> soldierMap = new Dictionary<string, GameObject>();
        foreach (GameObject soldier in AllSoldiersInGame)
        {
            string soldierID = soldier.GetComponent<Entity>().soldierID;
            soldierMap.Add(soldierID, soldier);
        }

        List<GameObject> orderedSoldiers = new List<GameObject>();

        foreach (string soldierID in GameManager.Instance.playerSoldierIDs)
        {
            if (soldierMap.ContainsKey(soldierID))
            {
                orderedSoldiers.Add(soldierMap[soldierID]);
            }
        }

        GameManager.Instance.PlayerSoldiers = orderedSoldiers;

        // :D
        float randomWaitTime = Random.Range(0,3);
        
        StartCoroutine(Load(randomWaitTime)); 
    }

    private IEnumerator Load(float randomTime)
    {
        yield return new WaitForSeconds(randomTime);

        SceneManager.LoadScene("MapScene");
    }
}
