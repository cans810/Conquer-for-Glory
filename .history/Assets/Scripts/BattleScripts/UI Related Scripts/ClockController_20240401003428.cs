using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        // Update the time text
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Check if the timer has reached 6 minutes
        if (timer >= 360) // 6 minutes * 60 seconds
        {
            // Access the BattleController script
            BattleController battleController = GameObject.FindObjectOfType<BattleController>();

            // Check the progress bar fill amount
            float fillAmount = battleController.progressBar.fillAmount;

            // Determine the outcome based on the fill amount
            if (fillAmount >= 0.5f)
            {
                battleController.playerWon = true;
                battleController.playerLost = false;
            }
            else
            {
                battleController.playerLost = true;
                battleController.playerWon = false;
            }
        }
    }
}
