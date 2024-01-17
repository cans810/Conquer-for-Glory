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

    public void playHurtSound(){
        int randomHurtSound = Random.Range(0,hurtSounds.Count);

        hurtSource.clip = hurtSounds[randomHurtSound]; 
    }
}
