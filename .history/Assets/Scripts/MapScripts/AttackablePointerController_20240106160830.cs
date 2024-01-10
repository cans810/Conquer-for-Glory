using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackablePointerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovered = false;
    Image imageComponent;

    void Start()
    {
        imageComponent = GetComponent<Image>(); // Get the Image component on Start
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    public void Update()
    {
        if (isHovered)
        {
            // Set the alpha of the Image component to 1 (fully visible)
            ChangeAlpha(1f);
            Debug.Log("Object is still being hovered.");
        }
        else
        {
            // Set the alpha of the Image component to 0.5 (partially visible)
            ChangeAlpha(0.5f);
        }
    }

    public void ChangeAlpha(float alphaValue)
    {
        Color color = imageComponent.color;
        color.a = alphaValue;
        imageComponent.color = color;
    }
}
