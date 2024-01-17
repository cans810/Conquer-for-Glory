using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public List<AudioClip> musics;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.volume = 0;

        int randomMusic = Random.Range(0,musics.Count);

        musicSource.clip = musics[randomMusic];

        PlayAndFade(musicSource);
    }

    private IEnumerator PlayAndFade(AudioSource source)
    {
        float fadeInDuration = 1f;

        float timer = 0f;

        source.Play();

        while (timer < fadeInDuration)
        {
            source.volume = Mathf.Lerp(0f, 1f, timer / fadeInDuration);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
