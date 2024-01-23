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

    public void Start(){
        GetComponent<SpriteRenderer>().sortingOrder = entity.GetComponent<Entity>().spawnedAtRow + 1;
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
        if (collision.gameObject.transform.Find("Fire(Clone)")){
            collision.gameObject.GetComponent<Entity>().animator.SetBool("Burn",false);
            collision.gameObject.transform.Find("Fire(Clone)").GetComponent<FireController>().stopFire();
        }

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
                if (!collision.gameObject.GetComponent<Entity>().burning){
                    collision.gameObject.GetComponent<Entity>().burning = true;
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playBurningScreamSound(9);
                    collision.gameObject.GetComponent<Entity>().animator.SetBool("Burn",true);
                    GameObject fireObject = Instantiate(firePrefab,collision.gameObject.transform.position,Quaternion.identity);

                    float scaleFactor = 0.25f;
                    fireObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

                    Vector3 offset = new Vector3(0.125f, 0.6f, 0f);
                    fireObject.transform.position += offset;

                    fireObject.GetComponent<SpriteRenderer>().sortingOrder = collision.gameObject.transform.GetComponent<Entity>().spawnedAtRow;

                    fireObject.transform.SetParent(collision.gameObject.transform);
                }
            }
        }
    }

    public void stopFirePile(){
        Destroy(gameObject);
    }
}
