using UnityEngine;
using UnityEngine.UI;

public class SelectedSoldierStats : MonoBehaviour
{
    public Image healthStat;
    public Image damageStat;
    public Image speedStat;
    public MarketManager marketManager;

    // Update is called once per frame
    void Update()
    {
        if (marketManager.actualSoldierGameObject != null)
        {
            Entity selectedSoldierStats = marketManager.actualSoldierGameObject.GetComponent<Entity>();

            if (selectedSoldierStats != null)
            {
                // Update fill amount based on soldier stats
                healthStat.fillAmount = (float)selectedSoldierStats.HP / 100f;
                damageStat.fillAmount = (float)selectedSoldierStats.damage / 100f;
                speedStat.fillAmount = (float)selectedSoldierStats.speed / 100f;
            }
        }
    }
}
