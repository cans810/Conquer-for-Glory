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
                fillAmount = 6;
            }
            if (otherCollider.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant")){
                fillAmount = 6;
            }
            battleController.GetComponent<BattleController>().playerProgress += 2.5f;
            Destroy(otherCollider.gameObject);
        }
    }
}
