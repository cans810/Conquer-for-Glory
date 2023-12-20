using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEndLineController : MonoBehaviour
{
    public GameObject battleController;
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag.Equals("Enemy")){
            battleController.GetComponent<BattleController>().playerProgress -= 2;
            Destroy(otherCollider.gameObject);
        }
    }
}
