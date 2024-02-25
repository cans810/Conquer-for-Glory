using UnityEngine;

public class ThrowableSpearController : MonoBehaviour
{
    public GameObject sourceEntity;
    public Rigidbody2D rb;
    public float forwardForce;
    public int spawnedAtRow;
    float spearDamage;

    void Start()
    {
        if (sourceEntity.GetComponent<Entity>().soldierType == "Warlord"){
            spearDamage = 3.7f;
        }
        else if (sourceEntity.GetComponent<Entity>().soldierType == "SpearThrower"){
            spearDamage = 1.8f;
        }

        spawnedAtRow = sourceEntity.GetComponent<Entity>().spawnedAtRow;

        transform.localScale = new Vector3(0.17f,0.24f,0.17f);
        
        if (sourceEntity.GetComponent<Entity>().direction.Equals("right")){
            transform.eulerAngles = new Vector3(0f, 0f, -90f);
        }
        else if (sourceEntity.GetComponent<Entity>().direction.Equals("left")){
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
        }
        rb = GetComponent<Rigidbody2D>();

        Vector2 direction = GetDirectionFromEntity();

        rb.velocity = direction * forwardForce;
    }

    Vector2 GetDirectionFromEntity()
    {
        Entity entityComponent = sourceEntity.GetComponent<Entity>();
        if (entityComponent != null)
        {
            string directionString = entityComponent.direction;
            Vector2 direction = Vector2.zero;

            switch (directionString)
            {
                case "right":
                    direction = Vector2.right;
                    break;
                case "left":
                    direction = Vector2.left;
                    break;
                default:
                    break;
            }

            return direction.normalized;
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
            if (collision.CompareTag("Enemy") && spawnedAtRow==collision.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                collision.GetComponent<Entity>().HP -= spearDamage;
                //collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playArrowSound(0);

                if (!collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSwordsman")
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon")){
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                Debug.Log("hit");
                Destroy(gameObject);
            }
        }
        else if (sourceEntity.tag.Equals("Enemy")){
            if (collision.CompareTag("Player") && spawnedAtRow==collision.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                collision.GetComponent<Entity>().HP -= 3.7f;
                //collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playArrowSound(0);
                
                if (!collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSwordsman")
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon")){
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                Debug.Log("hit");
                Destroy(gameObject);
            }
        }
    }
}