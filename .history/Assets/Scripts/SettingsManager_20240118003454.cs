using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsTab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void displaySettings(){
        settingsTab.SetActive(true);
    }

    public void closeSettingsTab(){
        settingsTab.SetActive(false);
    }
}
