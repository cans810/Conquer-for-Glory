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
        float fadeInDuration = 1f;
        float fadeOutDuration = 2.5f;

        float timer = 0f;

        // Get the screen position of the soldier
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

        // Convert screen position to a value between -1 and 1
        float stereoPan = (screenPosition.x / Screen.width) * 2 - 1;

        // Clamp the stereoPan value to limit left and right extremes
        float clampedStereoPan = Mathf.Clamp(stereoPan, -0.8f, 0.8f);

        // Set the stereo pan of the audio source
        source.panStereo = clampedStereoPan;

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
