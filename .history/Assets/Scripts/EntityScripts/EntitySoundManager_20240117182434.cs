using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySoundManager : MonoBehaviour
{
    public AudioSource hurtSource;
    public AudioSource weaponSource;
    public AudioSource deathSource;
    public AudioSource outsideEffectSource;

    public List<AudioClip> hurtSounds;
    public List<AudioClip> weaponSounds;
    public List<AudioClip> deathSounds;
    public List<AudioClip> arrowHitSounds;

    private bool IsPlaying(AudioSource source)
    {
        return source.isPlaying;
    }

    public void playHurtSound()
    {
        if (!IsPlaying(hurtSource))
        {
            // Get the screen position of the soldier
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            // Convert screen position to a value between -1 and 1
            float stereoPan = (screenPosition.x / Screen.width) * 2 - 1;

            // Clamp the stereoPan value to limit left and right extremes
            float clampedStereoPan = Mathf.Clamp(stereoPan, -0.75f, 0.75f);

            // Set the stereo pan of the audio source
            hurtSource.panStereo = clampedStereoPan;

            hurtSource.GetComponent<AudioLowPassFilter>().cutoffFrequency = 500f;

            int randomHurtSound = Random.Range(0, hurtSounds.Count);
            hurtSource.clip = hurtSounds[randomHurtSound];
            hurtSource.Play();
        }
    }

    public void playWeaponSound()
    {
        if (!IsPlaying(weaponSource))
        {
            // Get the screen position of the soldier
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            // Convert screen position to a value between -1 and 1
            float stereoPan = (screenPosition.x / Screen.width) * 2 - 1;

            // Clamp the stereoPan value to limit left and right extremes
            float clampedStereoPan = Mathf.Clamp(stereoPan, -0.75f, 0.75f);

            // Set the stereo pan of the audio source
            weaponSource.panStereo = clampedStereoPan;

            int randomWeaponSound = Random.Range(0, weaponSounds.Count);
            weaponSource.clip = weaponSounds[randomWeaponSound];
            weaponSource.Play();
        }
    }

    public void playDeathSound()
    {
        if (!IsPlaying(deathSource))
        {
            // Get the screen position of the soldier
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            // Convert screen position to a value between -1 and 1
            float stereoPan = (screenPosition.x / Screen.width) * 2 - 1;

            // Clamp the stereoPan value to limit left and right extremes
            float clampedStereoPan = Mathf.Clamp(stereoPan, -0.75f, 0.75f);

            // Set the stereo pan of the audio source
            deathSource.panStereo = clampedStereoPan;

            int randomDeathSound = Random.Range(0, deathSounds.Count);
            deathSource.clip = deathSounds[randomDeathSound];
            deathSource.Play();
        }
    }

    public void playArrowHitSound()
    {
        if (!IsPlaying(outsideEffectSource))
        {
            // Get the screen position of the soldier
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);

            // Convert screen position to a value between -1 and 1
            float stereoPan = (screenPosition.x / Screen.width) * 2 - 1;

            // Clamp the stereoPan value to limit left and right extremes
            float clampedStereoPan = Mathf.Clamp(stereoPan, -0.75f, 0.75f);

            // Set the stereo pan of the audio source
            outsideEffectSource.panStereo = clampedStereoPan;

            int arrowHitSound= Random.Range(0, arrowHitSounds.Count);
            outsideEffectSource.clip = arrowHitSounds[arrowHitSound];
            outsideEffectSource.Play();
        }
    }
}
