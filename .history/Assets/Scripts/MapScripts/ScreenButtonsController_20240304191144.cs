using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenButtonsController : MonoBehaviour
{
    public GameObject attackButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToMarket(){
        SceneManager.LoadScene("MarketScene");
    }
}
