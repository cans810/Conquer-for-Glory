using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject creditsGameObject;

    public void Awake(){
        creditsGameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showCreditsScreen(){
        creditsGameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    public void goBack(){
        creditsGameObject.SetActive(false);
        gameObject.SetActive(true);
    }

    public void advanceToRaceSelection(){
        SceneManager.LoadScene("RaceSelectionScene");
    }
}
