using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSoldierStats : MonoBehaviour
{
    public Image healthStat;
    public Image damageStat;
    public Image speedStat;
    public MarketManager marketManager;

    private GameObject instantiatedSoldier;

    public void AdjustSelectedSoldierStats()
    {
        if (marketManager.actualSoldierGameObject != null)
        {
            instantiatedSoldier = Instantiate(marketManager.actualSoldierGameObject, new Vector3(-1000f, 0f, 0f), Quaternion.identity);
            marketManager.actualSoldierGameObject = instantiatedSoldier;

            Entity selectedSoldierStats = instantiatedSoldier.GetComponent<Entity>();

            if (selectedSoldierStats != null)
            {
                // statlarının gelmesi için bekle
                StartCoroutine(WaitForStats(selectedSoldierStats));
            }
        }
    }

    IEnumerator WaitForStats(Entity stats)
    {
        while (stats.HP == 0 && stats.damage == 0 && stats.speed == 0)
        {
            yield return null;
        }

        healthStat.fillAmount = (float)stats.HP / 55f;
        damageStat.fillAmount = (float)stats.damage / 5f;
        speedStat.fillAmount = (float)stats.speed / 1.3f;

        Destroy(instantiatedSoldier.GetComponent<Animator>());
    }
}
