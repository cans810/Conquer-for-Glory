using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFireHitBoxController : MonoBehaviour
{
    Transform entityTransform;
    GameObject entity;

    public bool colliding;
    public List<GameObject> currentHittingOpponents;

    public void Awake()
    {
        entityTransform = transform.parent.transform;
        entity = entityTransform.gameObject;
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
        // Remove the exiting GameObject from the list
        currentHittingOpponents.Remove(collision.gameObject);

        // Check if there are still other objects in the hitbox
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
                currentHittingOpponents.Add(collision.gameObject);
            }
        }
    }
}
