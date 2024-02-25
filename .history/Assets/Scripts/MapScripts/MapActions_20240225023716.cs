using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActions : MonoBehaviour
{
    public GameObject InformPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableInformPlayer(){
        InformPlayer.SetActive(true);
    }
}
