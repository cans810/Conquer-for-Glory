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
            
        }
        if (GameManager.Instance.PlayerRace.Equals("Orc")){
            
        }
        if (GameManager.Instance.PlayerRace.Equals("Troll")){
            
        }
        if (GameManager.Instance.PlayerRace.Equals("Demon")){
            
        }
        if (GameManager.Instance.PlayerRace.Equals("EasternHuman")){
            
        }
        if (GameManager.Instance.PlayerRace.Equals("Wraith")){
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
