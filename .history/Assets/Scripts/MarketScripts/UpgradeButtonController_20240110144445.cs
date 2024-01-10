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

    public void Start(){
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

        if (currentParent == null)
        {
            Debug.Log("MarketCanvas not found.");
        }
    }

    public void Update()
    {
        level.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.playerUpgradeMap[gameObject.name].ToString();
        if (isHovered)
        {
            ChangeColor(new Color(0.83f, 0.1f, 0.6f, 1.0f));
        }
        else
        {
            ChangeColor(Color.grey);
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
    }

    public void OnMouseExit()
    {
        isHovered = false;
    }
}
