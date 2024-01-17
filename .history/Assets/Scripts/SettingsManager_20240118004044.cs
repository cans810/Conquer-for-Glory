using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public GameObject settingsTab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public float MusicVolume;
    void Start()
    {
        settingsTab.SetActive(false);
    }

    void Update()
    {

    }

    public void DisplaySettings()
    {
        settingsTab.SetActive(true);
    }

    public void CloseSettingsTab()
    {
        settingsTab.SetActive(false);
    }
}
