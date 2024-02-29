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

        Screen.fullScreen = false;
        FullScreenOn = false;
        Screen.SetResolution(1440, 768, false);

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

            // Calculate target aspect ratio
            float targetAspect = targetAspectRatio.x / targetAspectRatio.y;

            // Get the current screen's width and height
            float screenWidth = Screen.currentResolution.width;
            float screenHeight = Screen.currentResolution.height;

            // Calculate the current aspect ratio
            float currentAspect = screenWidth / screenHeight;

            // Calculate the desired width and height based on the target aspect ratio
            float targetWidth = screenHeight * targetAspect;
            float targetHeight = screenWidth / targetAspect;

            // Calculate the desired screen width and height based on the target aspect ratio
            int desiredWidth, desiredHeight;
            if (targetWidth <= screenWidth)
            {
                desiredWidth = Mathf.RoundToInt(targetWidth);
                desiredHeight = Mathf.RoundToInt(screenHeight);
            }
            else
            {
                desiredWidth = Mathf.RoundToInt(screenWidth);
                desiredHeight = Mathf.RoundToInt(targetHeight);
            }

            // Set the desired screen resolution
            Screen.SetResolution(desiredWidth, desiredHeight, false);

            Debug.Log(newWidth + "x" + desiredHeight);
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
