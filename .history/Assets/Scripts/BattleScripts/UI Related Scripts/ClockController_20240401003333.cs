using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI fillImage;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        if (time has reacged 6 minutes)
        {
            GameObject battleController = GameObject.Find("BattleController");

            if (battleProgressBar.GetComponent<ProgressBarFillScript>().fillImage.GetComponent<Image>().fillAmount >= 0.5f){
                battleController.GetComponent<BattleController>().playerWon = true;
                battleController.GetComponent<BattleController>().playerLost = false;
            }
            else{
                battleController.GetComponent<BattleController>().playerLost = true;
                battleController.GetComponent<BattleController>().playerWon = false;
            }
        }
    }
}
