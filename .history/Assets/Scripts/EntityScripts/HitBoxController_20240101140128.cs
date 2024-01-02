using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxController : MonoBehaviour
{
    Transform entityTransform;
    GameObject entity;
    // Start is called before the first frame update
    public bool colliding;
    public GameObject currentHittingOpponent;

    public void Awake(){
        entityTransform = transform.parent.transform;
        entity = entityTransform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (entity.tag.Equals("Player")){
            if (collision.CompareTag("Enemy"))
            {
                if (entity.GetComponent<Entity>().spawnedAtRow == collision.gameObject.GetComponent<Entity>().spawnedAtRow){
                    colliding = true;
                    currentHittingOpponent = collision.gameObject;
                }
            }
        }
        else if (entity.tag.Equals("Enemy")){
            if (collision.CompareTag("Player"))
            {
                if (entity.GetComponent<Entity>().spawnedAtRow == collision.gameObject.GetComponent<Entity>().spawnedAtRow){
                    colliding = true;
                    currentHittingOpponent = collision.gameObject;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (entity.tag.Equals("Player")){
            if (collision.CompareTag("Enemy"))
            {
                colliding = true;
                currentHittingOpponent = collision.gameObject;
            }
        }
        else if (entity.tag.Equals("Enemy")){
            if (collision.CompareTag("Player"))
            {
                colliding = true;
                currentHittingOpponent = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
        currentHittingOpponent = null;
    }
}
