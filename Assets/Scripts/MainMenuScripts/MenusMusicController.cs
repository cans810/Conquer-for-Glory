using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusMusicController : MonoBehaviour
{
    public static MenusMusicController Instance;

    public AudioSource musicSource;

    public bool fadeIn;
    public float timer;
    public float fadeInDuration;

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
        fadeInDuration = 3f;
    }

    private void Update()
    {
        if (fadeIn)
        {
            timer += Time.deltaTime;

            if (timer < fadeInDuration)
            {
                musicSource.volume = Mathf.Lerp(0f, SettingsManager.Instance.MusicVolume, timer / fadeInDuration);
            }
            else
            {
                musicSource.volume = SettingsManager.Instance.MusicVolume;
                fadeIn = false;
            }
        }
        else{
            musicSource.volume = SettingsManager.Instance.MusicVolume;
        }
    }

    public void StartFadeIn()
    {
        musicSource.UnPause();

        timer = 0f;
        fadeIn = true;
    }
}
