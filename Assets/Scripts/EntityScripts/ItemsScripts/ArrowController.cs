using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject sourceEntity;
    public Rigidbody2D rb;
    public float upwardForce = 10f;
    public float forwardForce = 5f;

    public float DestroyAfterYPos;

    void Start()
    {
        // Apply initial force to simulate arrow shooting
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(forwardForce, upwardForce);

        DestroyAfterYPos = sourceEntity.GetComponent<Entity>().HitBox.GetComponent<BoxCollider2D>().bounds.min.y;
    }

    void Update()
    {
        if (transform.position.y <= DestroyAfterYPos){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (sourceEntity.tag.Equals("Player")){
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Entity>().HP -= 1;
                Debug.Log("hit");
            }
        }
        else if (sourceEntity.tag.Equals("Enemy")){
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Entity>().HP -= 1;
                Debug.Log("hit");
            }
        }
    }
}