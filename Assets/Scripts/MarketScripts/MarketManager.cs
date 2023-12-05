using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.PlayerRace.Equals("Human")){
            HumanMarket.SetActive(true);
            ElfMarket.SetActive(false);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Elf")){
            HumanMarket.SetActive(false);
            ElfMarket.SetActive(true);
            OrcMarket.SetActive(false);
            TrollMarket.SetActive(false);
            DemonMarket.SetActive(false);
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectSoldier(){
        
    }

    public void buySelectedSoldier(){
        GameObject actualSoldierGameObject = null;

        if (currentSelectedSoldier.name.Equals("AxeMan")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().commonBuyableSoldiers[0];
        }
        else if (currentSelectedSoldier.name.Equals("MountedSpearMan")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().commonBuyableSoldiers[1];
        }
        else if (currentSelectedSoldier.name.Equals("MountedSwordsMan")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().commonBuyableSoldiers[2];
        }
        else if (currentSelectedSoldier.name.Equals("HatchetMan")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().commonBuyableSoldiers[3];
        }
        else if (currentSelectedSoldier.name.Equals("Sorcerer")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().commonBuyableSoldiers[4];
        }
        else if (currentSelectedSoldier.name.Equals("DoubleSwordsMan")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().ElfSpecialBuyableSoldiers[0];
        }
        else if (currentSelectedSoldier.name.Equals("KingsKnight")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[0];
        }
        else if (currentSelectedSoldier.name.Equals("DoubleEdgedBladeMan")){
            actualSoldierGameObject = GetComponent<HumanBuyableSoldiersContainer>().HumanSpecialBuyableSoldiers[0];
        }

        GameManager.Instance.PlayerSoldiers.Add(actualSoldierGameObject);
    }

    public void GoToMap(){
        SceneManager.LoadScene("MapScene");
    }
}
