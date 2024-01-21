using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BattleMusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public List<AudioClip> musics;
    public bool fadeInDone;

    // Start is called before the first frame update
    void Start()
    {
        // menü müziğini durdur
        MenusMusicController.Instance.musicSource.Pause();

        int randomMusic = Random.Range(0, musics.Count);
        musicSource.clip = musics[randomMusic];

        fadeInDone = false;

        musicSource.loop = true;

        StartCoroutine(PlayAndFade(musicSource));
    }

    private IEnumerator PlayAndFade(AudioSource source)
    {
        float fadeInDuration = 3f;

        source.Play();

        yield return null;

        float timer = 0f;

        while (timer < fadeInDuration)
        {
            source.volume = Mathf.Lerp(0f, SettingsManager.Instance.MusicVolume, timer / fadeInDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        fadeInDone = true;
    }

    public void Update(){

        if (fadeInDone){
            musicSource.volume = SettingsManager.Instance.MusicVolume;
            GameObject.Find("BattleScreenUI").GetComponent<BattleUIManager>().musicVolume = SettingsManager.Instance.MusicVolume;
            fadeInDone = false;
        }

    }
}
