using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeButtonController: MonoBehaviour
{
    GameObject market;

    public GameObject level;
    public int price;

    bool isHovered = false;
    public GameObject bg;
    public GameObject infoBubble;

    public void Start(){
        infoBubble.SetActive(false);

        Transform currentParent = transform.parent;

        while (currentParent != null)
        {
            if (currentParent.name == "MarketCanvas")
            {
                market = currentParent.gameObject;

                break;
            }
            else
            {
                currentParent = currentParent.parent;
            }
        }
    }

    public void Update()
    {
        level.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.playerUpgradeMap[gameObject.name].ToString();
        if (isHovered)
        {
            ChangeColor(Color.green);
        }
        else
        {
            ChangeColor(Color.white);
        }
    }

    public void ChangeColor(Color color)
    {
        bg.GetComponent<Image>().color = color;
    }

    private void OnMouseDown()
    {
        market.GetComponent<MarketManager>().currentSelectedUpgrade = gameObject;
    }

    public void OnMouseEnter()
    {
        isHovered = true;
        GetComponent<UpgradeButtonController>().infoBubble.SetActive(true);
    }

    public void OnMouseExit()
    {
        isHovered = false;
        GetComponent<UpgradeButtonController>().infoBubble.SetActive(false);
    }
}
