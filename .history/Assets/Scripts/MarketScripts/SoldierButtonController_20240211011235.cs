using UnityEngine;
using UnityEngine.UI;

public class SoldierButtonController : MonoBehaviour
{
    GameObject market;

    public GameObject background;

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
        market.GetComponent<MarketManager>().currentSelectedSoldier = gameObject;
        market.GetComponent<MarketManager>().findActualSoldierSelected();
        market.GetComponent<MarketManager>().selectedSoldierStatsManager.GetComponent<SelectedSoldierStats>().AdjustSelectedSoldierStats();
    }

    void OnMouseEnter()
    {
        background.GetComponent<Image>().color = new Color(184f/255f,184f/255f,184f/255f,174f/255f);
    }

    void OnMouseExit()
    {
        background.GetComponent<Image>().color = new Color(101f/255f,101f/255f,101f/255f,174f/255f);
    }
}