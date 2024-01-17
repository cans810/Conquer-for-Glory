using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsTab;

    public static SettingsManager Instance;

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

    // Start is called before the first frame update
    void Start()
    {
        settingsTab.SetActive(false);
    }

    // Update is called once per frame
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
