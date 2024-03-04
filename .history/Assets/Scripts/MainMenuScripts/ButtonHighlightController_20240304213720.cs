using UnityEngine;
using UnityEngine.UI;

public class ButtonHighlightController : MonoBehaviour
{
    private Button button;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        originalColor = button.colors.normalColor;
    }

    public void OnButtonPressed()
    {
        // Highlight the button temporarily
        button.image.color = new Color();

        // Invoke method to reset button color after a brief delay
        Invoke("ResetButtonColor", 0.2f);
    }

    private void ResetButtonColor()
    {
        // Reset button color to original color
        button.image.color = originalColor;
    }
}
