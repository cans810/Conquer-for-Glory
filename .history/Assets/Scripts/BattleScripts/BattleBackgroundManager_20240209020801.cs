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
            int randomWeather = Random.Range(0,2);
            weather.GetComponent<SpriteRenderer>().sprite = weathers[randomWeather];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Elf"){
            int randomWeather = Random.Range(0,3);
            weather.GetComponent<SpriteRenderer>().sprite = weathers[randomWeather];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Orc"){
            int randomWeather = Random.Range(0,2);
            weather.GetComponent<SpriteRenderer>().sprite = weathers[randomWeather];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Troll"){
            int randomWeather = Random.Range(0,3);
            weather.GetComponent<SpriteRenderer>().sprite = weathers[randomWeather];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Demon"){
            int randomWeather = Random.Range(0,4);
            if (randomWeather == 0 || randomWeather == 1){
                weather.GetComponent<SpriteRenderer>().sprite = weathers[0];
            }
            else if (randomWeather == 2 || randomWeather == 3){
                weather.GetComponent<SpriteRenderer>().sprite = weathers[2];
            }
        }
        if (GameManager.Instance.CurrentEnemyRace == "EasternHuman"){
            int randomWeather = Random.Range(1,4);
            weather.GetComponent<SpriteRenderer>().sprite = weathers[randomWeather];
        }
        if (GameManager.Instance.CurrentEnemyRace == "Wraith"){
            int randomWeather = Random.Range(0,4);
            if (randomWeather == 0 || randomWeather == 1){
                weather.GetComponent<SpriteRenderer>().sprite = weathers[0];
            }
            else if (randomWeather == 2 || randomWeather == 3){
                weather.GetComponent<SpriteRenderer>().sprite = weathers[2];
            }
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
