using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEndLineController : MonoBehaviour
{
    public GameObject battleController;
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag.Equals("Player")){
            battleController.GetComponent<BattleController>().playerProgress += 1;
            Destroy(otherCollider.gameObject);
        }
    }
}
