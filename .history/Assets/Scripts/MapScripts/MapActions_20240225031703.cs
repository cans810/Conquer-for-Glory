using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapActions : MonoBehaviour
{
    public GameObject InformPlayer;
    public GameObject Map;

    // Start is called before the first frame update
    void Start()
    {
        InformPlayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enableInformPlayer(){
        InformPlayer.SetActive(true);
    }
    public void closeInform(){
        Map.GetComponent<Animator>().SetBool("SeaElvesRise",false);
        InformPlayer.SetActive(false);
    }
}
