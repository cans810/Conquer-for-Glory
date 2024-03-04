using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePileController : MonoBehaviour
{
    public GameObject entity;

    public bool colliding;
    public List<GameObject> currentHittingOpponents;
    public GameObject firePrefab;

    public void Start(){
        GetComponent<SpriteRenderer>().sortingLayerName = entity.GetComponent<Entity>().spawnedAtRow.ToString();
        GetComponent<SpriteRenderer>().sortingOrder = 28;
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
        if (collision.gameObject.GetComponent<Entity>()){
            if (collision.gameObject.GetComponent<Entity>().canBurn){
                if (collision.gameObject.transform.Find("Fire(Clone)")){
                    foreach (AnimatorControllerParameter parameter in collision.gameObject.GetComponent<Entity>().animator.parameters)
                    {
                        if (parameter.name == "Burn" && parameter.type == AnimatorControllerParameterType.Bool)
                        {
                            collision.gameObject.GetComponent<Entity>().animator.SetBool("Burn",false);
                            break;
                        }
                    }
                    collision.gameObject.transform.Find("Fire(Clone)").GetComponent<FireController>().stopFire();
                }
            }
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
                if (!collision.gameObject.GetComponent<Entity>().burning && collision.gameObject.GetComponent<Entity>().canBurn){
                    collision.gameObject.GetComponent<Entity>().burning = true;
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playBurningScreamSound(9);

                    if (collision.gameObject.GetComponent<Entity>().soldierType != "Mammoth" && collision.gameObject.GetComponent<Entity>().soldierType != "Minotaur" &&
                    collision.gameObject.GetComponent<Entity>().soldierType != "TrollGiant" 
                    && collision.gameObject.GetComponent<Entity>().soldierType != "EasternLion"
                    && collision.gameObject.GetComponent<Entity>().soldierType != "WraithCaller"
                    && collision.gameObject.GetComponent<Entity>().soldierType != "Skeleton" && collision.gameObject.GetComponent<Entity>().soldierType != "Cthulhu" 
                    && collision.gameObject.GetComponent<Entity>().soldierType != "Skeleton"){
                        collision.gameObject.GetComponent<Entity>().animator.SetBool("Burn",true);
                    }

                    GameObject fireObject = Instantiate(firePrefab,collision.gameObject.transform.position,Quaternion.identity);

                    float scaleFactor = 0.25f;

                    fireObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

                    Vector3 offset = new Vector3(0.125f, 0.6f, 0f);
                    fireObject.transform.position += offset;

                    fireObject.GetComponent<SpriteRenderer>().sortingLayerName = collision.gameObject.GetComponent<Entity>().spawnedAtRow.ToString();
                    fireObject.GetComponent<SpriteRenderer>().sortingOrder = 29;

                    fireObject.transform.SetParent(collision.gameObject.transform);
                }
            }
        }
    }

    public void stopFirePile(){
        Destroy(gameObject);
    }
}
