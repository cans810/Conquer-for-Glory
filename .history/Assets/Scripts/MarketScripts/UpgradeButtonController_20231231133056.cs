using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UpgradeButtonController: MonoBehaviour
{
    GameObject market;

    public GameObject level;
    public int price;

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

    public void Update(){
        level.GetComponent<TextMeshProUGUI>().text = GameManager.Instance.playerUpgradeMap[gameObject.name].ToString();
    }

    private void OnMouseDown()
    {
        market.GetComponent<MarketManager>().currentSelectedUpgrade = gameObject;

        market.GetComponent<MarketManager>().currentSelectedUpgradeInfoText.GetComponent<TextMeshProUGUI>().text = price.ToString();
    }
}
