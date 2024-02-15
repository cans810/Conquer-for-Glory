using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleBackgroundManager : MonoBehaviour
{
    public GameObject weather;
    public List<Sprite> backgrounds;
    public List<Sprite> weathers;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Instance.CurrentEnemyRace == "Human"){
            int[] weathersSpecific = {0,1,2};

            int randomWeather = Random.Range(0,weathersSpecific.Length);

            weather.GetComponent<SpriteRenderer>().sprite = weathers[weathersSpecific[randomWeather]];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Elf"){
            int[] weathersSpecific = {0,1,2,4};

            int randomWeather = Random.Range(0,weathersSpecific.Length);

            weather.GetComponent<SpriteRenderer>().sprite = weathers[weathersSpecific[randomWeather]];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Orc"){

            weather.GetComponent<SpriteRenderer>().sprite = weathers[randomWeather];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Troll"){

            weather.GetComponent<SpriteRenderer>().sprite = weathers[randomWeather];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Demon"){

        }
        if (GameManager.Instance.CurrentEnemyRace == "EasternHuman"){

        }
        if (GameManager.Instance.CurrentEnemyRace == "Wraith"){

        }


        if (GameManager.Instance.CurrentEnemyRace == "Human"){
            GetComponent<SpriteRenderer>().sprite = backgrounds[0];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Elf"){
            GetComponent<SpriteRenderer>().sprite = backgrounds[1];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Orc"){
            GetComponent<SpriteRenderer>().sprite = backgrounds[2];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Troll"){
            GetComponent<SpriteRenderer>().sprite = backgrounds[3];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Demon"){
            GetComponent<SpriteRenderer>().sprite = backgrounds[4];
        }
        if (GameManager.Instance.CurrentEnemyRace == "EasternHuman"){
            GetComponent<SpriteRenderer>().sprite = backgrounds[5];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Wraith"){
            GetComponent<SpriteRenderer>().sprite = backgrounds[6];
        }
    }
}
