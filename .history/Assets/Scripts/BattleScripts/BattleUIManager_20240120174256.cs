using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIManager : MonoBehaviour
{
    public void loadMapScene(){
        MenusMusicController.Instance.musicSource.UnPause();
        SceneManager.LoadScene("MapScene");
    }

    public void winBattle(){
        GameManager.Instance.AllConqueredCityNames.Add(GameManager.Instance.CurrentEnemyName);
        GameManager.Instance.balance += 300;

        SceneManager.LoadScene("MapScene");
    }
}
