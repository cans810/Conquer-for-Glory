using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySoundManager : MonoBehaviour
{
    public AudioSource hurtSource;
    public AudioSource weaponSource;
    public AudioSource deathSource;

    public List<AudioClip> hurtSounds;
    public List<AudioClip> weaponSounds;
    public List<AudioClip> deathSounds;

    private bool IsPlaying(AudioSource source)
    {
        return source.isPlaying;
    }

    public void PlayHurtSound()
    {
        if (!IsPlaying(hurtSource))
        {
            int randomHurtSound = Random.Range(0, hurtSounds.Count);
            hurtSource.clip = hurtSounds[randomHurtSound];
            hurtSource.Play();
        }
    }

    public void PlayWeaponSound()
    {
        if (!IsPlaying(weaponSource))
        {
            int randomWeaponSound = Random.Range(0, weaponSounds.Count);
            weaponSource.clip = weaponSounds[randomWeaponSound];
            weaponSource.Play();
        }
    }

    public void PlayDeathSound()
    {
        if (!IsPlaying(deathSource))
        {
            int randomDeathSound = Random.Range(0, deathSounds.Count);
            deathSource.clip = deathSounds[randomDeathSound];
            deathSource.Play();
        }
    }
}
