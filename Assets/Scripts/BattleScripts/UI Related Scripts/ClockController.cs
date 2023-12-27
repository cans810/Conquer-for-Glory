using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockController : MonoBehaviour
{
    public float timer;
    public GameObject fillImage;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;

        float fillAmount = Mathf.Clamp01(timer / 360f);

        if (fillImage != null)
        {
            fillImage.GetComponent<Image>().fillAmount = fillAmount;
        }

        if (fillImage.GetComponent<Image>().fillAmount == 1)
        {
            GameObject battleController = GameObject.Find("BattleController");
            battleController.GetComponent<BattleController>().playerWon = false;
            battleController.GetComponent<BattleController>().playerLost = true;
        }
    }
}
