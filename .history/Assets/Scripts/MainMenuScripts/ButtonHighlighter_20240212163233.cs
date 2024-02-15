using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlighter : MonoBehaviour
{
    public GameObject text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.GetComponent<TextMeshProUGUI>().color = new Color(161f/255f,0,0,1);
        Debug.Log("Hovering");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.GetComponent<TextMeshProUGUI>().color = new Color(50f/255f,50f/255f,50f/255f,1);
    }
}
