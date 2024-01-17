using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGroundSoundsManager : MonoBehaviour
{
    public AudioSource playerSideSounds;
    public AudioSource enemySideSounds;
    public List<AudioClip> sounds;

    public void Awake(){
        playerSideSounds.volume = 0;
        enemySideSounds.volume = 0;
    }

    private IEnumerator PlayAndFade(AudioSource source)
    {
        float fadeInDuration = 2f;
        float fadeOutDuration = 2f;

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

    public void playUltiSound(string side)
    {
        if (side == "Player")
        {
            playerSideSounds.clip = sounds[0];
            StartCoroutine(PlayAndFade(playerSideSounds));
        }
        else if (side == "Enemy")
        {
            enemySideSounds.clip = sounds[0];
            StartCoroutine(PlayAndFade(enemySideSounds));
        }
    }
}
