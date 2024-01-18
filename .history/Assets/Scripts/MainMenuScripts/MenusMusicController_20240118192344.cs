using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenusMusicController : MonoBehaviour
{
    public static MenusMusicController Instance;

    public AudioSource musicSource;

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
    }

    public void Update(){
        musicSource.volume = SettingsManager.Instance.MusicVolume;

        if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            musicSource.Stop();
        }

        
    }
}
