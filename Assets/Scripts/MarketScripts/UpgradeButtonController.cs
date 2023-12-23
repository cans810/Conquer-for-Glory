using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpgradeButtonController: MonoBehaviour
{
    GameObject market;

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

    private void OnMouseDown()
    {
        market.GetComponent<MarketManager>().currentSelectedUpgrade= gameObject;
    }
}
