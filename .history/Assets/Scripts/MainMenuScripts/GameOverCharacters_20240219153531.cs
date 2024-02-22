using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCharacters : MonoBehaviour
{
    public List<GameObject> soldiers;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.PlayerRace.Equals("Human")){
            soldiers[0].SetActive(true);
        }
        if (GameManager.Instance.PlayerRace.Equals("Elf")){
            soldiers[1].SetActive(true);
        }
        if (GameManager.Instance.PlayerRace.Equals("Orc")){
            soldiers[2].SetActive(true);
        }
        if (GameManager.Instance.PlayerRace.Equals("Troll")){
            soldiers[3].SetActive(true);
        }
        if (GameManager.Instance.PlayerRace.Equals("Demon")){
            soldiers[4].SetActive(true);
        }
        if (GameManager.Instance.PlayerRace.Equals("EasternHuman")){
            soldiers[5].SetActive(true);
        }
        if (GameManager.Instance.PlayerRace.Equals("Wraith")){
            soldiers[0].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
