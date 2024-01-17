using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public GameObject settingsTab;

    public Slider musicVolumeSlider;

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
        musicVolumeSlider.onValueChanged.AddListener(OnSliderValueChanged);
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
    
    public void OnSliderValueChanged(float value)
    {
        MusicVolume = value/10f;
    }
}
