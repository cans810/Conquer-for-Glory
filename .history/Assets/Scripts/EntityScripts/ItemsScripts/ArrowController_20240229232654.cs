using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject sourceEntity;
    public Rigidbody2D rb;
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

        float randomAngle = UnityEngine.Random.Range(sourceEntity.GetComponent<ArcherController>().arrowLowerAngleBound,sourceEntity.GetComponent<ArcherController>().arrowUpperAngleBound);

        direction = Quaternion.Euler(0, 0, randomAngle) * direction;

        rb.velocity = direction * sourceEntity.GetComponent<ArcherController>().forwardForce;
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
                collision.GetComponent<Entity>().HP -= 1;

                if (!collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman")
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon")){
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                if (collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant")
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && collision.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast") 
                || collision.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon")){
                    int randomHitChance = Random.Range(0,100);

                    if (randomHitChance <= 35){

                    }
                }

                Debug.Log("hit");
                Destroy(gameObject);
            }
        }
        else if (sourceEntity.tag.Equals("Enemy")){
            if (collision.CompareTag("Player") && spawnedAtRow==collision.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                collision.GetComponent<Entity>().HP -= 1;
                
                if (!collision.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion") 
                && !collision.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman")
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