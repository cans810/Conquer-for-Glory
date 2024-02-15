using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MarketManager : MonoBehaviour
{   
    public GameObject HumanMarket;
    public GameObject ElfMarket;
    public GameObject OrcMarket;
    public GameObject TrollMarket;
    public GameObject DemonMarket;
    public GameObject EasternHumanMarket;
    public GameObject WraithMarket;

    public GameObject currentSelectedSoldier;
    public GameObject currentSelectedSoldierInfoText;
    public GameObject actualSoldierGameObject;

    public GameObject currentSelectedUpgrade;
    public GameObject currentSelectedUpgradeInfoText;


    public GameObject playerBalance;
    public GameObject selectedSoldierPrice;

    public GameObject selectedUpgradePrice;
    public GameObject selectedSoldierStatsManager;

    public GameObject errorText;

    public int speedUpgradeLimit = 3;
    public int armourUpgradeLimit = 3;
    public int archerUpgradeLimit = 3;

    // Start is called before the first frame update
    void Start()
    {
        errorText.SetActive(false);

        if (GameManager.Instance.PlayerRace.Equals("Human")){
            HumanMarket.SetActive(true);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);
            EasternHumanMarket.SetActive(false);
            WraithMarket.SetActive(false);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = HumanMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                                
                    if (string.Equals(child.gameObject.name, soldier.GetComponent<Entity>().soldierType, StringComparison.OrdinalIgnoreCase)){
                        Destroy(child.gameObject);
                    }
                }
            }
        }
        else if (GameManager.Instance.PlayerRace.Equals("Elf")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(true);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);
            EasternHumanMarket.SetActive(false);
            WraithMarket.SetActive(false);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = ElfMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                                
                    if (string.Equals(child.gameObject.name, soldier.GetComponent<Entity>().soldierType, StringComparison.OrdinalIgnoreCase)){
                        Destroy(child.gameObject);
                    }
                }
            }
        }
        else if (GameManager.Instance.PlayerRace.Equals("Orc")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(true);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);
            EasternHumanMarket.SetActive(false);
            WraithMarket.SetActive(false);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = OrcMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                                
                    if (string.Equals(child.gameObject.name, soldier.GetComponent<Entity>().soldierType, StringComparison.OrdinalIgnoreCase)){
                        Destroy(child.gameObject);
                    }
                }
            }
            
        }
        else if (GameManager.Instance.PlayerRace.Equals("Troll")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(true);
            DemonMarket.SetActive(false);
            EasternHumanMarket.SetActive(false);
            WraithMarket.SetActive(false);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = TrollMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                                
                    if (string.Equals(child.gameObject.name, soldier.GetComponent<Entity>().soldierType, StringComparison.OrdinalIgnoreCase)){
                        Destroy(child.gameObject);
                    }
                }
            }
        }
        else if (GameManager.Instance.PlayerRace.Equals("Demon")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(true);
            EasternHumanMarket.SetActive(false);
            WraithMarket.SetActive(false);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = DemonMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                                
                    if (string.Equals(child.gameObject.name, soldier.GetComponent<Entity>().soldierType, StringComparison.OrdinalIgnoreCase)){
                        Destroy(child.gameObject);
                    }
                }
            }
        }

        else if (GameManager.Instance.PlayerRace.Equals("EasternHuman")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);
            EasternHumanMarket.SetActive(true);
            WraithMarket.SetActive(false);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = EasternHumanMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                                
                    if (string.Equals(child.gameObject.name, soldier.GetComponent<Entity>().soldierType, StringComparison.OrdinalIgnoreCase)){
                        Destroy(child.gameObject);
                    }
                }
            }
        }

        else if (GameManager.Instance.PlayerRace.Equals("Wraith")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);
            EasternHumanMarket.SetActive(false);
            WraithMarket.SetActive(true);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = WraithMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                                
                    if (string.Equals(child.gameObject.name, soldier.GetComponent<Entity>().soldierType, StringComparison.OrdinalIgnoreCase)){
                        Destroy(child.gameObject);
                    }
                }
            }
        }

    }


    public void buySelectedUpgrade(){
        errorText.SetActive(false);

        if (GameManager.Instance.balance >= currentSelectedUpgrade.GetComponent<UpgradeButtonController>().price){
            if (currentSelectedUpgradeInfoText.GetComponent<TextMeshProUGUI>().text.Equals("Speed Training") && GameManager.Instance.speedTrainingPoint < 3){
                GameManager.Instance.speedTrainingPoint += 1;
            }
            else if(GameManager.Instance.speedTrainingPoint >= 3){
                errorText.SetActive(true);
                errorText.GetComponent<Animator>().SetBool("ShowError",false);
                errorText.GetComponent<Animator>().SetBool("ShowError",true);
                errorText.GetComponent<TextMeshProUGUI>().text = "You can't upgrade more!";
            }

            if (currentSelectedUpgradeInfoText.GetComponent<TextMeshProUGUI>().text.Equals("Armour Increase") && GameManager.Instance.armourIncreasePoint < 3){
                GameManager.Instance.armourIncreasePoint += 1;
            }
            else if(GameManager.Instance.armourIncreasePoint >= 3){
                errorText.SetActive(true);
                errorText.GetComponent<Animator>().SetBool("ShowError",false);
                errorText.GetComponent<Animator>().SetBool("ShowError",true);
                errorText.GetComponent<TextMeshProUGUI>().text = "You can't upgrade more!";
            }

            if (currentSelectedUpgradeInfoText.GetComponent<TextMeshProUGUI>().text.Equals("Archery") && GameManager.Instance.archeryPoint < 3){
                GameManager.Instance.archeryPoint += 1;
            }
            else if(GameManager.Instance.archeryPoint >= 3){
                errorText.SetActive(true);
                errorText.GetComponent<Animator>().SetBool("ShowError",false);
                errorText.GetComponent<Animator>().SetBool("ShowError",true);
                errorText.GetComponent<TextMeshProUGUI>().text = "You can't upgrade more!";
            }

            GameManager.Instance.balance -= currentSelectedUpgrade.GetComponent<UpgradeButtonController>().price;
        }

        else{
            errorText.SetActive(true);
            errorText.GetComponent<Animator>().SetBool("ShowError",false);
            errorText.GetComponent<Animator>().SetBool("ShowError",true);
            errorText.GetComponent<TextMeshProUGUI>().text = "Insufficient Gold...";
        }
    }

    public void buySelectedSoldier(){
        errorText.SetActive(false);
        findActualSoldierSelected();

        if (GameManager.Instance.balance >= currentSelectedSoldier.GetComponent<SoldierMarketController>().price){
            GameManager.Instance.balance -= currentSelectedSoldier.GetComponent<SoldierMarketController>().price;
            GameManager.Instance.PlayerSoldiers.Add(actualSoldierGameObject);
            GameManager.Instance.playerSoldierIDs.Add(actualSoldierGameObject.GetComponent<Entity>().soldierID);
            Destroy(currentSelectedSoldier);
        }
        else{
            errorText.SetActive(true);
            errorText.GetComponent<Animator>().SetBool("ShowError",false);
            errorText.GetComponent<Animator>().SetBool("ShowError",true);
            errorText.GetComponent<TextMeshProUGUI>().text = "Insufficient Gold...";
        }

    }

    public void Update(){
    
        playerBalance.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.balance.ToString();

        if (currentSelectedSoldier == null){
            currentSelectedSoldierInfoText.GetComponent<TextMeshProUGUI>().text = "";
            selectedSoldierPrice.GetComponent<TextMeshProUGUI>().text = "";
        }

        else if (currentSelectedSoldier != null){
            currentSelectedSoldierInfoText.GetComponent<TextMeshProUGUI>().text = currentSelectedSoldier.name;
            selectedSoldierPrice.GetComponent<TextMeshProUGUI>().text = currentSelectedSoldier.GetComponent<SoldierMarketController>().price.ToString();
        }

        if(currentSelectedUpgrade != null){
            currentSelectedUpgradeInfoText.GetComponent<TextMeshProUGUI>().text = currentSelectedUpgrade.transform.Find("Text (TMP)").gameObject.GetComponent<TextMeshProUGUI>().text;

            selectedUpgradePrice.GetComponent<TextMeshProUGUI>().text = currentSelectedUpgrade.GetComponent<UpgradeButtonController>().price.ToString();
        } 

        else if(currentSelectedUpgrade == null){
            currentSelectedUpgradeInfoText.GetComponent<TextMeshProUGUI>().text = "";
            selectedUpgradePrice.GetComponent<TextMeshProUGUI>().text = "";
        } 
    }

    public void GoToMap(){
        SceneManager.LoadScene("MapScene");
    }

    public void findActualSoldierSelected(){
        
        if (GameManager.Instance.PlayerRace.Equals("Human")){

                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("DualBladeChampion")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("StormBringer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[5];
                    }
                }
                if (GameManager.Instance.PlayerRace.Equals("Elf")){
                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("QueensKnight")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("Minotaur")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[5];
                    }
                }
                if (GameManager.Instance.PlayerRace.Equals("Orc")){
                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("DoubleSidedRavager")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("OrcBeast")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[5];
                    }
                }
                if (GameManager.Instance.PlayerRace.Equals("Demon")){
                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("Darklord")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("Dragon")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[5];
                    }
                }
                if (GameManager.Instance.PlayerRace.Equals("Troll")){
                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("SpearMaster")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("TrollGiant")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[5];
                    }
                }
                if (GameManager.Instance.PlayerRace.Equals("EasternHuman")){
                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().EasternHumanSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().EasternHumanSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().EasternHumanSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().EasternHumanSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("EasternLion")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().EasternHumanSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("Warlord")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().EasternHumanSpecialBuyableSoldiers[5];
                    }
                }
                if (GameManager.Instance.PlayerRace.Equals("Wraith")){
                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().WraithSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().WraithSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().WraithSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().WraithSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("Mammoth")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().WraithSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("WraithCaller")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().WraithSpecialBuyableSoldiers[5];
                    }
                }
    }
}
