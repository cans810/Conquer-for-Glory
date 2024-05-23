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
        GameManager.Instance.playerSoldierIDs
        GameManager.Instance.LoadGameData();

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

        // load player color

        if (GameManager.Instance.PlayerRace.Equals("Human")){
            GameManager.Instance.playerLandColor = new Color(97f/255f,76f/255f,53f/255f,1);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Elf")){
            GameManager.Instance.playerLandColor = new Color(63f/255f,84f/255f,51f/255f,1);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Orc")){
            GameManager.Instance.playerLandColor = new Color(51f/255f,68f/255f,41f/255f,1);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Troll")){
            GameManager.Instance.playerLandColor = new Color(72f/255f,66f/255f,58f/255f,1);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Demon")){
            GameManager.Instance.playerLandColor = new Color(62f/255f,45f/255f,41f/255f,1);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Wraith")){
            GameManager.Instance.playerLandColor = new Color(116f/255f,116f/255f,116f/255f,1);
        }
        else if (GameManager.Instance.PlayerRace.Equals("EasternHuman")){
            GameManager.Instance.playerLandColor = new Color(53f/255f,91f/255f,36f/255f,1);
        }
        else if (GameManager.Instance.PlayerRace.Equals("SeaElf")){
            GameManager.Instance.playerLandColor = new Color(63f/255f,98f/255f,176f/255f,1);
        }

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
