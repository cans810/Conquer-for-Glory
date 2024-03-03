using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndLineController : MonoBehaviour
{
    public GameObject battleController;
    public float fillAmount;

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag.Equals("Player")){
            if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant")){
                fillAmount = 3.5f;
            }
            else if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("Mammoth")){
                fillAmount = 3.5f;
            }
            else if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast")){
                fillAmount = 3.5f;
            }
            else if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur")){
                fillAmount = 3.5f;
            }
            else if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("StormBringer")){
                fillAmount = 3.5f;
            }
            else if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("Warlord")){
                fillAmount = 3.5f;
            }
            else if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("WraithCaller")){
                fillAmount = 4;
            }
            else if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu")){
                fillAmount = 4;
            }
            else{
                fillAmount = 2.5f;
            }
            battleController.GetComponent<BattleController>().playerProgress += fillAmount;
            Destroy(otherCollider.gameObject);
        }
    }
}
