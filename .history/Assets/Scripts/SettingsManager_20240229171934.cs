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

// Get the current screen width and height
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        float targetAspectRatio = 1440f / 768f;

        // Calculate the current aspect ratio
        float currentAspectRatio = (float)screenWidth / screenHeight;

        // Check if the current aspect ratio is close to the target aspect ratio
        if (Mathf.Approximately(currentAspectRatio, targetAspectRatio))
        {
            // If already close, no need to change resolution
            return;
        }

        // Calculate the new resolution width and height
        int newWidth, newHeight;
        if (currentAspectRatio < targetAspectRatio)
        {
            // Wider screen, adjust height
            newWidth = Mathf.RoundToInt(screenHeight * targetAspectRatio);
            newHeight = screenHeight;
        }
        else
        {
            // Taller screen, adjust width
            newWidth = screenWidth;
            newHeight = Mathf.RoundToInt(screenWidth / targetAspectRatio);
        }

        // Set the new screen resolution
        Screen.SetResolution(newWidth, newHeight, false);



            Debug.Log(newWidth + "x" + newHeight);
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
