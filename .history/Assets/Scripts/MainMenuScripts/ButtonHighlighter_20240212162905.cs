using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonHighlighter : MonoBehaviour
{
    public GameObject text;

    public void OnMouseEnter()
    {
        text.GetComponent<TextMeshProUGUI>().color = new Color(161f/255f,0,0,1);
        Debug.Log("hovering");
    }

    public void OnMouseExit()
    {
        text.GetComponent<TextMeshProUGUI>().color = new Color(50f/255f,50f/255f,50f/255f,1);
    }
}
