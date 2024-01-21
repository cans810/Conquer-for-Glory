using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusMusicController : MonoBehaviour
{
    public static MenusMusicController Instance;

    public AudioSource musicSource;

    public bool fadeIn;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Start(){
        musicSource.loop = true;
        musicSource.Play();
        musicSource.volume = SettingsManager.Instance.MusicVolume;
    }

    public IEnumerator FadeInVolume(AudioSource source)
    {
        float fadeInDuration = 3f;

        source.UnPause();

        float timer = 0f;

        fadeIn = true;

        while (timer < fadeInDuration)
        {
            source.volume = Mathf.Lerp(0f, 1, timer / fadeInDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        fadeIn = false;
    }

    public void Update(){

        if (!fadeIn){
            musicSource.volume = SettingsManager.Instance.MusicVolume;
        }

    }
}
