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

    public GameObject currentSelectedSoldier;
    public GameObject currentSelectedSoldierInfoText;

    public GameObject currentSelectedUpgrade;
    public GameObject currentSelectedUpgradeInfoText;


    public GameObject playerBalance;
    public GameObject selectedSoldierPrice;

    public GameObject selectedUpgradePrice;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.PlayerRace.Equals("Human")){
            HumanMarket.SetActive(true);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = HumanMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                    if (child.gameObject.name.Equals(soldier.GetComponent<Entity>().soldierType)){
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

            //eğer zaten marketteki askerlerden biri oyuncuda varsa o zaman o askeri marketten çıkar
            Transform parentTransform = ElfMarket.transform;

            foreach (GameObject soldier in GameManager.Instance.PlayerSoldiers){

                for (int i = 0; i < parentTransform.childCount; i++)
                {
                    Transform child = parentTransform.GetChild(i);
                    if (child.gameObject.name.Equals(soldier.GetComponent<Entity>().soldierType)){
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
        }
        else if (GameManager.Instance.PlayerRace.Equals("Troll")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(true);
            DemonMarket.SetActive(false);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Demon")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(true);
        }

    }


    public void buySelectedUpgrade(){
        
    }

    public void buySelectedSoldier(){
        GameObject actualSoldierGameObject = null;

        if (GameManager.Instance.balance >= currentSelectedSoldier.GetComponent<SoldierMarketController>().price){
                if (GameManager.Instance.PlayerRace.Equals("Human")){

                    if (currentSelectedSoldier.name.Equals("AxeMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[0];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[1];
                    }
                    else if (currentSelectedSoldier.name.Equals("MountedSwordsMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("KingsKnight")){
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
                    else if (currentSelectedSoldier.name.Equals("MountedSwordsMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("DoubleSwordsMan")){
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
                    else if (currentSelectedSoldier.name.Equals("MountedSwordsMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().OrcSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("DoubleEdgedBladeMan")){
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
                    else if (currentSelectedSoldier.name.Equals("MountedSwordsMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().DemonSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("SpearMaster")){
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
                    else if (currentSelectedSoldier.name.Equals("MountedSwordsMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[2];
                    }
                    else if (currentSelectedSoldier.name.Equals("HatchetMan")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[3];
                    }
                    else if (currentSelectedSoldier.name.Equals("Sorcerer")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[4];
                    }
                    else if (currentSelectedSoldier.name.Equals("TrollGiant")){
                        actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().TrollSpecialBuyableSoldiers[5];
                    }
                }

                GameManager.Instance.balance -= currentSelectedSoldier.GetComponent<SoldierMarketController>().price;
                Destroy(currentSelectedSoldier);
                GameManager.Instance.PlayerSoldiers.Add(actualSoldierGameObject);
        }
        else{
            Debug.Log("Your balance is not enough");
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
        } 
    }

    public void GoToMap(){
        SceneManager.LoadScene("MapScene");
    }
}
