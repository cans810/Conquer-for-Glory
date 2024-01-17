using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleGroundSoundsManager : MonoBehaviour
{
    public AudioSource playerSideSounds;
    public AudioSource enemySideSounds;
    public List<AudioClip> sounds;

    // Start is called before the first frame update
    void Start()
    {
        int randomMusic = Random.Range(0,musics.Count);

        musicSource.clip = musics[randomMusic];

        musicSource.Play();
    }
}
