using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CityInfo : MonoBehaviour
{
    public bool isConqueredByPlayer;
    public string cityName;
    public string cityRaceType;

    public GameObject textObject;
    public GameObject buttonObject;

    public List<GameObject> Soldiers;

    public void Awake(){
        
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isConqueredByPlayer){
            cityName = "You";
            cityRaceType = GameManager.Instance.PlayerRace;
            textObject.GetComponent<TextMeshProUGUI>().text = cityName;
            buttonObject.GetComponent<Button>().interactable = false;
        }
        else{
            textObject.GetComponent<TextMeshProUGUI>().text = cityName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enterBattle(){

        GameManager.Instance.CurrentEnemyName = cityName;
        GameManager.Instance.CurrentEnemyRace = cityRaceType;

        GameManager.Instance.CurrentEnemySoldiers = Soldiers;

        SceneManager.LoadScene("BattleScene");

    }
}
