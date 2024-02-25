using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class RaceSelectionController : MonoBehaviour
{
    public GameObject currentRaceSelectedText;
    public List<string> racesNames;

    public int currentRace;

    public GameObject currentSoldierShowcase;
    public List<SpriteLibraryAsset> RaceModels;
    public GameObject[] baseHumanSoldiers;
    public GameObject[] baseElfSoldiers;
    public GameObject[] baseOrcSoldiers;
    public GameObject[] baseDemonSoldiers;
    public GameObject[] baseTrollSoldiers;
    public GameObject[] baseEasternHumanSoldiers;
    public GameObject[] baseWraithSoldiers;
    public GameObject[] baseSeaElfSoldiers;

    public bool addedSeaElfs;

    public List<string> raceInfos;
    public GameObject infoText;
    public GameObject LockObject;
    public GameObject ContinueButton;

    // Start is called before the first frame update
    void Start()
    {
        addedSeaElfs = false;
        
        racesNames.Add("Human");
        racesNames.Add("Elf");
        racesNames.Add("Orc");
        racesNames.Add("Demon");
        racesNames.Add("Troll");
        racesNames.Add("EasternHuman");
        racesNames.Add("Wraith");

        LockObject.SetActive(false);

        currentRace = 0;
        currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = racesNames[currentRace];

        raceInfos.Add("+ SwordsMan HP");
        raceInfos.Add("+ Archer Damage");
        raceInfos.Add("+ SwordsMan Damage\n + AxeMan Damage");
        raceInfos.Add("+ SpearMan Damage\n + SpearMan HP");
        raceInfos.Add("+ Walking Speed");
        raceInfos.Add("+ SwordsMan Damage\n + SwordsMan HP");
        raceInfos.Add("+ Walking Speed\n + Sorcerer Damage");
        raceInfos.Add("+ Improved Ranged Attack\n + Overall HP");
        
        infoText.GetComponent<TextMeshProUGUI>().text = raceInfos[currentRace];
    }

    // Update is called once per frame
    void Update()
    {
        currentSoldierShowcase.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[currentRace];

        if (racesNames[currentRace].Equals("Demon") && GameManager.Instance.finishedGameCtr < 1){
            ContinueButton.GetComponent<Button>().interactable = false;
            LockObject.SetActive(true);
            SetSpriteRenderersBlackRecursive(currentSoldierShowcase,Color.black);
            currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = "???";
            infoText.GetComponent<TextMeshProUGUI>().text = "???";
        }
        else if (racesNames[currentRace].Equals("Wraith") && GameManager.Instance.finishedGameCtr < 2){
            ContinueButton.GetComponent<Button>().interactable = false;
            LockObject.SetActive(true);
            SetSpriteRenderersBlackRecursive(currentSoldierShowcase,Color.black);
            currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = "???";
            infoText.GetComponent<TextMeshProUGUI>().text = "???";
        }
        else{
            ContinueButton.GetComponent<Button>().interactable = true;
            LockObject.SetActive(false);
            SetSpriteRenderersBlackRecursive(currentSoldierShowcase,Color.white);
        }

        if (GameManager.Instance.finishedGameCtr >= 3 && !addedSeaElfs){
            racesNames.Add("SeaElf");
        }
    }

    void SetSpriteRenderersBlackRecursive(GameObject obj,Color color)
    {
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && !obj.name.Equals("Lock"))
        {
            spriteRenderer.color = color;
        }

        foreach (Transform child in obj.transform)
        {
            SetSpriteRenderersBlackRecursive(child.gameObject,color);
        }
    }

    public void nextRace(){
        if (currentRace < racesNames.Count-1){
            currentRace++;

            currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = racesNames[currentRace];
            infoText.GetComponent<TextMeshProUGUI>().text = raceInfos[currentRace];
        }
    }

    public void prevRace(){
        if (currentRace > 0){
            currentRace--;

            currentRaceSelectedText.GetComponent<TextMeshProUGUI>().text = racesNames[currentRace];
            infoText.GetComponent<TextMeshProUGUI>().text = raceInfos[currentRace];
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
        if (GameManager.Instance.PlayerRace.Equals("EasternHuman")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseEasternHumanSoldiers);
        }
        if (GameManager.Instance.PlayerRace.Equals("Wraith")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseWraithSoldiers);
        }
        if (GameManager.Instance.PlayerRace.Equals("SeaElf")){
            GameManager.Instance.PlayerSoldiers.AddRange(baseSeaElfSoldiers);
        }

        foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){
            GameManager.Instance.playerSoldierIDs.Add(soldier.GetComponent<Entity>().soldierID);
        }


        SceneManager.LoadScene("MapScene");

    }
}
