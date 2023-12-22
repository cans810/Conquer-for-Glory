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
    public GameObject imageObject;
    public List<GameObject> Soldiers;

    public List<GameObject> Neighbours;

    public bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        if (isConqueredByPlayer){
            buttonObject.GetComponent<Button>().interactable = false;
            cityName = "You";
            cityRaceType = GameManager.Instance.PlayerRace;
            textObject.GetComponent<TextMeshProUGUI>().text = cityName;

            GameManager.Instance.playerLandColor = imageObject.GetComponent<SpriteRenderer>().color;
        }
        else{
            if (!canAttack){
                buttonObject.GetComponent<Button>().interactable = false;
            }
            else if (canAttack){
                buttonObject.GetComponent<Button>().interactable = true;
            }

            textObject.GetComponent<TextMeshProUGUI>().text = cityName;
        }

    }

    public void enterBattle(){
        GameManager.Instance.CurrentEnemyName = cityName;
        GameManager.Instance.CurrentEnemyRace = cityRaceType;

        GameManager.Instance.CurrentEnemySoldiers = Soldiers;

        SceneManager.LoadScene("BattleScene");
    }
}
