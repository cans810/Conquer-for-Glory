using UnityEngine;
using UnityEngine.UI;

public class ProgressBarFillScript : MonoBehaviour
{
    public GameObject battleController;
    public GameObject fillImage;

    private float currentFillAmount = 0.5f; // Start at 50%
    public float fillSpeed = 0.5f; // Adjust this value for fill speed

    // Update is called once per frame
    void Update()
    {
        float targetFillAmount = (battleController.GetComponent<BattleController>().playerProgress / 100f);
        
        // Gradually change the fill amount
        currentFillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, Time.deltaTime * fillSpeed);

        if (fillImage.GetComponent<Image>() != null)
        {
            fillImage.GetComponent<Image>().fillAmount = currentFillAmount;
        }

        if (battleController.GetComponent<BattleController>().playerProgress >= 100){
            battleController.GetComponent<BattleController>().playerWon = true;
        }
        else if (battleController.GetComponent<BattleController>().playerProgress <= 0){
            battleController.GetComponent<BattleController>().playerLost = true;
        }
    }
}
