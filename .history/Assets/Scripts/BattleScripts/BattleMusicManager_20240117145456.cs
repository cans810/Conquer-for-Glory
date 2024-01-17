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
        int randomMusic = Random.Range(0,musics.Count);

        musicSource.clip = musics[randomMusic];

        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
