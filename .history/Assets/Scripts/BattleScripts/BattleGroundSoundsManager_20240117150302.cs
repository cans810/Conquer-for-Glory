using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGroundSoundsManager : MonoBehaviour
{
    public AudioSource playerSideSounds;
    public AudioSource enemySideSounds;
    public List<AudioClip> sounds;

    public void playUltiSound(string side)
    {
        if (side == "Player"){
            playerSideSounds.clip = sounds[0];

            playerSideSounds.Play();
        }
        else if (side == "Enemy"){
            enemySideSounds.clip = sounds[0];

            enemySideSounds.Play();
        }
    }
}
