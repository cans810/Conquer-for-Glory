using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePileController : MonoBehaviour
{
    public GameObject entity;

    public bool colliding;
    public List<GameObject> currentHittingOpponents;

    public void Awake()
    {
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        CheckCollision(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        currentHittingOpponents.Remove(collision.gameObject);

        if (currentHittingOpponents.Count == 0)
        {
            colliding = false;
        }
    }

    private void CheckCollision(Collider2D collision)
    {
        if ((entity.tag.Equals("Player") && collision.CompareTag("Enemy")) ||
            (entity.tag.Equals("Enemy") && collision.CompareTag("Player")))
        {
            if (entity.GetComponent<Entity>().spawnedAtRow == collision.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                colliding = true;
                if (!currentHittingOpponents.Contains(collision.gameObject)){
                    currentHittingOpponents.Add(collision.gameObject);
                }
            }
        }
    }
}
