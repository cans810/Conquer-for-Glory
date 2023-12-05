using UnityEngine;

public class MagicBulbController : MonoBehaviour
{
    public GameObject sourceEntity;
    public Rigidbody2D rb;
    public float forwardForce = 7f;
    public float rotationSpeed = 200f;

    void Start()
    {
        if (sourceEntity.GetComponent<Entity>().direction.Equals("right")){
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (sourceEntity.GetComponent<Entity>().direction.Equals("left")){
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = GetDirectionFromEntity();

        // Apply force in the direction specified by the entity's direction string
        rb.velocity = direction * forwardForce;

        rb.AddTorque(rotationSpeed);
    }

    Vector2 GetDirectionFromEntity()
    {
        Entity entityComponent = sourceEntity.GetComponent<Entity>();
        if (entityComponent != null)
        {
            string directionString = entityComponent.direction; // Assuming direction is stored as a string in the Entity component
            Vector2 direction = Vector2.zero;

            // Set the direction based on the string value
            switch (directionString)
            {
                case "right":
                    direction = Vector2.right;
                    break;
                case "left":
                    direction = Vector2.left;
                    break;
                // Add more cases for other directions if needed
                default:
                    break;
            }

            return direction.normalized; // Normalize the direction vector before using it for velocity
        }

        return Vector2.zero;
    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x < 0 || screenPos.x > Screen.width)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (sourceEntity.tag.Equals("Player")){
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Entity>().HP -= 1.5f;
                Debug.Log("hit");
                Destroy(gameObject);
            }
        }
        else if (sourceEntity.tag.Equals("Enemy")){
            if (collision.CompareTag("Player"))
            {
                collision.GetComponent<Entity>().HP -= 1.5f;
                Debug.Log("hit");
                Destroy(gameObject);
            }
        }
    }
}