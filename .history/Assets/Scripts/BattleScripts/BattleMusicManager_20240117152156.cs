using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusicManager : MonoBehaviour
{
    public AudioSource musicSource;
    public List<AudioClip> musics;

    public void Awake(){
        musicSource.volume = 0;
    }

    private IEnumerator PlayAndFade(AudioSource source)
    {
        float fadeInDuration = 2.5f;

        float timer = 0f;

        source.Play();

        while (timer < fadeInDuration)
        {
            source.volume = Mathf.Lerp(0f, 1f, timer / fadeInDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(2f);

        timer = 0f;
        while (timer < fadeOutDuration)
        {
            source.volume = Mathf.Lerp(1f, 0f, timer / fadeOutDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        source.Stop();
        source.volume = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        int randomMusic = Random.Range(0,musics.Count);

        musicSource.clip = musics[randomMusic];

        musicSource.Play();
    }
}
