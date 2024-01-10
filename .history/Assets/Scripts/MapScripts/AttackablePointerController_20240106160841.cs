using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AttackablePointerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovered = false;
    Image imageComponent;

    void Start()
    {
        imageComponent = GetComponent<Image>();
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
            Debug.Log("Object is still being hovered.");
        }
        else
        {
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
