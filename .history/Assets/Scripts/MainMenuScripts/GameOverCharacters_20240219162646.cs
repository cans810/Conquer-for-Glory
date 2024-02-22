using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverCharacters : MonoBehaviour
{
    public List<GameObject> soldiers;
    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        text.GetComponent<TextMeshProUGUI>().text = "
In the chronicles of time, amidst the clash of empires and the cries of the fallen, a single figure rises above the fray. Driven by an unyielding thirst for power, the Demon carves a path of conquest through realms stained with the blood of warriors. Kingdoms tremble at their approach, for none can stand against the relentless tide of domination. After decades of war, the conqueror stands triumphant, their name etched into the very fabric of history as the unrivaled ruler of realms."

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
}
