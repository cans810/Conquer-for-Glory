using UnityEngine;

public class MagicBulbController : MonoBehaviour
{
    public GameObject sourceEntity;
    public Rigidbody2D rb;
    public float forwardForce = 4f;
    public float rotationSpeed = 200f;
    public int spawnedAtRow;

    void Start()
    {
        spawnedAtRow = sourceEntity.GetComponent<Entity>().spawnedAtRow;

        if (sourceEntity.GetComponent<Entity>().direction.Equals("right")){
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (sourceEntity.GetComponent<Entity>().direction.Equals("left")){
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = GetDirectionFromEntity();

        int randomAngle = UnityEngine.Random.Range(-5,5);

        direction = Quaternion.Euler(0, 0, randomAngle) * direction;


        rb.velocity = direction * forwardForce;

        rb.AddTorque(rotationSpeed);
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
        if (screenPos.x < -100 || screenPos.x > Screen.width+100)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (sourceEntity.tag.Equals("Player")){
            if (collision.CompareTag("Enemy") && spawnedAtRow==collision.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                if (!collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman")
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Mammoth")){
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                if (collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant")
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") || collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu")
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Mammoth")){
                    int randomHitChance = Random.Range(0,100);

                    if (randomHitChance > 10){
                        collision.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                    }
                }
                else{
                    collision.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                }

                Destroy(gameObject);
            }
        }
        else if (sourceEntity.tag.Equals("Enemy")){
            if (collision.CompareTag("Player") && spawnedAtRow==collision.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                if (!collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman")
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu")
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Mammoth")){
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                if (collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant")
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") || collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu")
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Mammoth")){
                    int randomHitChance = Random.Range(0,100);

                    if (randomHitChance > 10){
                        collision.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                    }
                }
                else{
                    collision.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                }

                Destroy(gameObject);
            }
        }
    }
}