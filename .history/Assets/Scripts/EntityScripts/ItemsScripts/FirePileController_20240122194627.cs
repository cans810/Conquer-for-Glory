using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePileController : MonoBehaviour
{
    public GameObject entity;

    public bool colliding;
    public List<GameObject> currentHittingOpponents;
    public GameObject firePrefab;

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
                    
                    collision.gameObject.GetComponent<Entity>().burning = true;
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playBurningScreamSound(9);
                    collision.gameObject.GetComponent<Entity>().animator.SetBool("Burn",true);
                    GameObject fireObject = Instantiate(firePrefab,collision.gameObject.transform.position,Quaternion.identity);

                    float scaleFactor = 0.25f;
                    fireObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

                    Vector3 offset = new Vector3(0.2f, 0.7f, 0f);
                    fireObject.transform.position += offset;

                    fireObject.transform.SetParent(collision.gameObject.transform);
                }
            }
        }
    }
}
