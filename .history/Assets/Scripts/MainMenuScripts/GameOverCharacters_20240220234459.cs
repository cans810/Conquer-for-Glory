using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCharacters : MonoBehaviour
{
    public List<GameObject> soldiers;
    public GameObject MainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.SetActive(false);

        soldiers[0].SetActive(false);
        soldiers[1].SetActive(false);
        soldiers[2].SetActive(false);
        soldiers[3].SetActive(false);
        soldiers[4].SetActive(false);
        soldiers[5].SetActive(false);
        soldiers[6].SetActive(false);

        if (GameManager.Instance.PlayerRace.Equals("Human")){
            soldiers[0].SetActive(true);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Elf")){
            soldiers[1].SetActive(true);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Orc")){
            soldiers[2].SetActive(true);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Troll")){
            soldiers[3].SetActive(true);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Demon")){
            soldiers[4].SetActive(true);
        }
        else if (GameManager.Instance.PlayerRace.Equals("EasternHuman")){
            soldiers[5].SetActive(true);
        }
        else if (GameManager.Instance.PlayerRace.Equals("Wraith")){
            soldiers[6].SetActive(true);
        }
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenuScene");
    }
}
