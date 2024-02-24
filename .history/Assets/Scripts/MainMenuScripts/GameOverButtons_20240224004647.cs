using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtons : MonoBehaviour
{
    public GameObject MainMenuButton;
    public GameObject ScreenFade;
    public GameObject InformPlayer;

    public void Awake(){
        
        ScreenFade.GetComponent<Animator>().SetBool("FadeIn",true);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setMainMenuButtonActive(){
        ScreenFade.SetActive(false);
        MainMenuButton.SetActive(true);
    }
}
