using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIManager : MonoBehaviour
{
    public void loadMapScene()
    {
        SceneManager.LoadScene("MapScene");

        MenusMusicController.Instance.StartFadeIn();
    }

    public void winBattle(){
        GameManager.Instance.AllConqueredCityNames.Add(GameManager.Instance.CurrentEnemyName);
        GameManager.Instance.balance += 300;
        GameManager.Instance.DynamicDifficulty += 1;

        SceneManager.LoadScene("MapScene");
    }

    public void surrender(){
        battleEnded = true;
            loseCanvas.SetActive(true);

        SceneManager.LoadScene("MapScene");
    }
}
