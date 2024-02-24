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
        }
        else if (SceneManager.GetActiveScene().name.Equals("MainMenuScene") && GameObject.Find("Credits")){
            // ekrandan çıkar
            settingsButton.transform.localPosition = new Vector3(-2000,340,0);
        }
        else if (SceneManager.GetActiveScene().name.Equals("MapScene")){
            settingsButton.transform.localPosition = new Vector3(0,350,0);
            saveGameButton.SetActive(true);
            mainMenuButton.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name.Equals("BattleScene")){
            settingsButton.transform.localPosition = new Vector3(-125,340,0);
            saveGameButton.SetActive(true);
            mainMenuButton.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name.Equals("GameOverScene")){
            settingsButton.transform.localPosition = new Vector3(-2000,340,0);
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
