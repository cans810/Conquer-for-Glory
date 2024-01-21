using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIManager : MonoBehaviour
{
    public void loadMapScene()
    {
        StartCoroutine(FadeInVolume(MenusMusicController.Instance.musicSource));

        SceneManager.LoadScene("MapScene");
    }

    private IEnumerator FadeInVolume(AudioSource source)
    {
        float fadeInDuration = 3f;

        MenusMusicController.Instance.musicSource.UnPause();

        yield return null;

        float timer = 0f;

        while (timer < fadeInDuration)
        {
            source.volume = Mathf.Lerp(0f, SettingsManager.Instance.MusicVolume, timer / fadeInDuration);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    public void winBattle(){
        GameManager.Instance.AllConqueredCityNames.Add(GameManager.Instance.CurrentEnemyName);
        GameManager.Instance.balance += 300;

        SceneManager.LoadScene("MapScene");
    }
}
