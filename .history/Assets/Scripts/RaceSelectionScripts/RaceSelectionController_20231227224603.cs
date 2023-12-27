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

    public GameObject[] baseHumanSoldiers;
    public GameObject[] baseElfSoldiers;
    public GameObject[] baseOrcSoldiers;
    public GameObject[] baseDemonSoldiers;
    public GameObject[] baseTrollSoldiers;

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
        
        if (GameManager.Instance.PlayerRace.Equals("Human")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseHumanSoldiers);
        }
        if (GameManager.Instance.PlayerRace.Equals("Elf")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseElfSoldiers);
        }
        if (GameManager.Instance.PlayerRace.Equals("Orc")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseOrcSoldiers);
        }
        if (GameManager.Instance.PlayerRace.Equals("Demon")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseDemonSoldiers);
        }
        if (GameManager.Instance.PlayerRace.Equals("Troll")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseTrollSoldiers);
        }


        SceneManager.LoadScene("MapScene");

    }
}
