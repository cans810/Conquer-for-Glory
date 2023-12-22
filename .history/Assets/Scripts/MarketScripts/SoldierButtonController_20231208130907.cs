using UnityEngine;

public class SoldierButtonController : MonoBehaviour
{
    GameObject market;

    public void Start(){
        Transform currentParent = transform.parent;

        while (currentParent != null)
        {
            if (currentParent.name == "MarketCanvas")
            {
                // Found the MarketCanvas GameObject!
                market = currentParent.gameObject;
                // Do something with marketCanvas or its components

                break; // Exit the loop since we found the MarketCanvas
            }
            else
            {
                // Move up to the next parent
                currentParent = currentParent.parent;
            }
        }

        if (currentParent == null)
        {
            // The MarketCanvas GameObject was not found in the hierarchy
            Debug.Log("MarketCanvas not found.");
        }
    }

    private void OnMouseDown()
    {
        market.GetComponent<MarketManager>().currentSelectedSoldier = gameObject;
    }
}