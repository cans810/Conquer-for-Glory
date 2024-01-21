using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIManager : MonoBehaviour
{
    public float musicVolume;

    public void loadMapScene()
    {
        StartCoroutine(MenusMusicController.Instance.FadeInVolume(MenusMusicController.Instance.musicSource));

        SceneManager.LoadScene("MapScene");
    }

    public void winBattle(){
        GameManager.Instance.AllConqueredCityNames.Add(GameManager.Instance.CurrentEnemyName);
        GameManager.Instance.balance += 300;

        SceneManager.LoadScene("MapScene");
    }
}
