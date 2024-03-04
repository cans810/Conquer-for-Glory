using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSoldiers : MonoBehaviour
{
    public List<GameObject> AllSoldiersInGame;

    public GameObject loadingText;

    public void LoadGame(){
        GameManager.Instance.LoadGameData();
        
        if (GameManager.Instance.playerLandColorString.Equals("human"))

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
        float randomWaitTime = Random.Range(2,3);
        
        StartCoroutine(Load(randomWaitTime)); 
    }

    private IEnumerator Load(float randomTime)
    {
        yield return new WaitForSeconds(randomTime);

        SceneManager.LoadScene("MapScene");
    }

    public void loadingTextAnim1(){
        loadingText.GetComponent<TextMeshProUGUI>().text = "Loading your last save.";
    }
    public void loadingTextAnim2(){
        loadingText.GetComponent<TextMeshProUGUI>().text = "Loading your last save..";
    }
    public void loadingTextAnim3(){
        loadingText.GetComponent<TextMeshProUGUI>().text = "Loading your last save...";
    }
}
