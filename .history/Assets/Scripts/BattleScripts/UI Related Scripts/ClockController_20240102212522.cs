using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
    public float timer;
    public GameObject fillImage;
    public GameObject battleProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        float fillAmount = Mathf.Clamp01(timer / 60f); // 360

        if (fillImage != null)
        {
            fillImage.GetComponent<Image>().fillAmount = fillAmount;
        }

        if (fillImage.GetComponent<Image>().fillAmount == 1)
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
