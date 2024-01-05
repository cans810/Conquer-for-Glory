using UnityEngine;
using UnityEngine.UI;

public class SelectedSoldierStats : MonoBehaviour
{
    public Image healthStat;
    public Image damageStat;
    public Image speedStat;
    public MarketManager marketManager;

    private GameObject instantiatedSoldier;

    void Start(){

    }

    void Update()
    {
        
    }

    public void adjustSelectedSoldierStats(){
        if (marketManager.actualSoldierGameObject != null)
        {
            // soldier'ın statlarına erişebilmek için önce oluşturmak gerekiyor
            instantiatedSoldier = Instantiate(marketManager.actualSoldierGameObject, transform.position, Quaternion.identity);
            marketManager.actualSoldierGameObject = instantiatedSoldier;

            Entity selectedSoldierStats = marketManager.actualSoldierGameObject.GetComponent<Entity>();

            if (selectedSoldierStats != null)
            {
                healthStat.fillAmount = (float)selectedSoldierStats.HP / 10f;
                damageStat.fillAmount = (float)selectedSoldierStats.damage / 10f;
                speedStat.fillAmount = (float)selectedSoldierStats.speed / 10f;
            }
        }
    }

}
