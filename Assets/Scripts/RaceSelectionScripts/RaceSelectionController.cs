using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceSelectionController : MonoBehaviour
{

    public GameObject racesContainerGameObject;
    public GameObject currentRaceSelectedText;

    int currentRace;

    public GameObject[] baseSoldiers;

    // Start is called before the first frame update
    void Start()
    {
        currentRace = 0;
        currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = racesContainerGameObject.GetComponent<RacesManager>().racesNames[currentRace];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextRace(){
        if (currentRace < racesContainerGameObject.GetComponent<RacesManager>().racesNames.Count-1){
            currentRace++;

            currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = racesContainerGameObject.GetComponent<RacesManager>().racesNames[currentRace];
        }
    }

    public void prevRace(){
        if (currentRace > 0){
            currentRace--;

            currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = racesContainerGameObject.GetComponent<RacesManager>().racesNames[currentRace];
        }
    }

    public void setCurrentRaceAndContinue(){
        GameManager.Instance.PlayerRace = currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text;
        GameManager.Instance.PlayerSoldiers.AddRange(baseSoldiers);
        SceneManager.LoadScene("MapScene");

    }
}
