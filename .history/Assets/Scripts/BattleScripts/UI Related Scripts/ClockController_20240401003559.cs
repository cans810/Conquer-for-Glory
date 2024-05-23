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

        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timer >= 360)
        {
            BattleController battleController = GameObject.Find("BattleController").GetComponent<BattleController>();

            if (battleController.pla)
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
