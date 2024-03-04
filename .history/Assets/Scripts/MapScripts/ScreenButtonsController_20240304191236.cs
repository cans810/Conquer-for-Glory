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
        attackButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentEnemyName != "" && GameManager.Instance.CurrentEnemyRace != "" && (GameManager.Instance.CurrentEnemySoldiers != null || 
            GameManager.Instance.CurrentEnemySoldiers.Count != 0)){
                attackButton.SetActive(true);
        }
        else{
            attackButton.SetActive(false);
        }
    }

    public void GoToMarket(){
        SceneManager.LoadScene("MarketScene");
    }

    public void GoToMarket(){
        SceneManager.LoadScene("MarketScene");
    }
}
