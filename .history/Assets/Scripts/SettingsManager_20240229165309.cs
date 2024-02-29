using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public GameObject canvas;

    public GameObject settingsButton;
    public GameObject settingsTab;

    public Slider musicVolumeSlider;

    public Slider battleSoundsVolumeSlider;

    public GameObject progressSavedText;

    public GameObject mainMenuButton;
    public GameObject saveGameButton;

    public bool FullScreenOn;

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
    public float BattleSoundsVolume;
    public bool autoSummon;

    void Start()
    {
        // base value for music volume
        MusicVolume = 0.5f;

        // base value for battlesounds volume
        BattleSoundsVolume = 0.5f;

        autoSummon = false;
        FullScreenOn = false;

        musicVolumeSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        battleSoundsVolumeSlider.onValueChanged.AddListener(OnBattleSoundsSliderValueChanged);
        settingsTab.SetActive(false);
        progressSavedText.SetActive(false);
    }

    void Update()
    {
        canvas.GetComponent<Canvas>().worldCamera = Camera.main;
        
        if (SceneManager.GetActiveScene().name.Equals("MainMenuScene")){
            saveGameButton.SetActive(false);
            mainMenuButton.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Equals("MarketScene")){
            // ekrandan çıkar
            settingsButton.transform.localPosition = new Vector3(-2000,344,0);
            settingsTab.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name.Equals("MainMenuScene") && GameObject.Find("Credits")){
            // ekrandan çıkar
            settingsButton.transform.localPosition = new Vector3(-2000,340,0);
            settingsTab.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name.Equals("MapScene")){
            settingsButton.transform.localPosition = new Vector3(0,350,0);
            saveGameButton.SetActive(true);
            mainMenuButton.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            settingsButton.transform.localPosition = new Vector3(-125,336,0);
            saveGameButton.SetActive(false);
            mainMenuButton.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name.Equals("GameOverScene")){
            settingsButton.transform.localPosition = new Vector3(-2000,340,0);
            settingsTab.SetActive(false);
        }
        else{
            settingsButton.transform.localPosition = new Vector3(-497,252,0);
        }
    }

    public void DisplaySettings()
    {
        settingsTab.SetActive(true);
    }

    public void CloseSettingsTab()
    {
        settingsTab.SetActive(false);
    }
    
    public void OnMusicSliderValueChanged(float value)
    {
        MusicVolume = value;
    }

    public void OnBattleSoundsSliderValueChanged(float value)
    {
        BattleSoundsVolume = value;
    }
    

    public void SetAutoSummon(){
        if (autoSummon){
            autoSummon = false;
        }
        else if (!autoSummon){
            autoSummon = true;
        }
    }

    public void setFullScreen()
    {
        if (FullScreenOn){
            FullScreenOn = false;

            Screen.SetResolution(1440, 768, false);
        }
        else if (!FullScreenOn){
            FullScreenOn = true;

    // Get the maximum available screen resolution
            Resolution maxResolution = Screen.resolutions[Screen.resolutions.Length - 1];

            // Calculate the aspect ratio of the screen
            float screenAspectRatio = (float)maxResolution.width / (float)maxResolution.height;

            // Calculate the aspect ratio of 15:8
            float targetAspectRatio = 15f / 8f; // 1440 / 768

            int width;
            int height;

            // Check if the screen aspect ratio is wider than 15:8
            if (screenAspectRatio > targetAspectRatio)
            {
                // Calculate the height based on the width
                width = maxResolution.width;
                height = Mathf.RoundToInt(width / targetAspectRatio);
            }
            else
            {
                // Calculate the width based on the height
                height = maxResolution.height;
                width = Mathf.RoundToInt(height * targetAspectRatio);
            }

            // Set the screen resolution to the calculated width and height
            Screen.SetResolution(width, height, false);
            }
    }

    public void GoToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene");
        CloseSettingsTab();
    }

    public IEnumerator displaySavedText(){
        progressSavedText.SetActive(true);
        
        yield return new WaitForSeconds(1.5f);

        progressSavedText.SetActive(false);
    }
}
