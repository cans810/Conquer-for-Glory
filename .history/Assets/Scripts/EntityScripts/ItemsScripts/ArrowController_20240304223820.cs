using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public GameObject sourceEntity;
    private Rigidbody2D rb;
    private Animator animator;
    private Entity entityComponent;

    public int spawnedAtRow;

    // Start is called before the first frame update
    void Start()
    {
        spawnedAtRow = entityComponent.spawnedAtRow;

        if (entityComponent.direction.Equals("right"))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (entityComponent.direction.Equals("left"))
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
        }

        Vector2 direction = GetDirectionFromEntity();

        float randomAngle = Random.Range(sourceEntity.GetComponent<ArcherController>().arrowLowerAngleBound, sourceEntity.GetComponent<ArcherController>().arrowUpperAngleBound);

        direction = Quaternion.Euler(0, 0, randomAngle) * direction;

        rb.velocity = direction * sourceEntity.GetComponent<ArcherController>().forwardForce;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entityComponent = sourceEntity.GetComponent<Entity>();
    }

    Vector2 GetDirectionFromEntity()
    {
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
        if (screenPos.x < -100 || screenPos.x > Screen.width + 100)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D entityHit)
    {
        Entity entityHit = entityHit.gameObject.GetComponent<Entity>();
        
        if (sourceEntity.tag.Equals("Player"))
        {
            if (entityHit.CompareTag("Enemy") && spawnedAtRow == entityHit.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                if (!entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion")
                && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman")
                && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast")
                && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu"))
                {
                    entityHit.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                if (entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant")
                || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast")
                || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu"))
                {
                    int randomHitChance = Random.Range(0, 100);

                    if (randomHitChance > 35)
                    {
                        entityHit.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                        Destroy(gameObject);
                    }
                    else
                    {
                        rb.velocity = Vector2.zero;
                        animator.SetBool("Break", true);
                    }
                }
                else
                {
                    entityHit.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                    Destroy(gameObject);
                }

                Destroy(gameObject);
            }
        }
        else if (sourceEntity.tag.Equals("Enemy"))
        {
            if (entityHit.CompareTag("Player") && spawnedAtRow == entityHit.gameObject.GetComponent<Entity>().spawnedAtRow)
            {
                if (!entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant") && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("EasternLion")
                && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("MountedSpearman")
                && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast")
                && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") && !entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu"))
                {
                    entityHit.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                if (entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("TrollGiant")
                || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Minotaur") || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("OrcBeast")
                || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Dragon") || entityHit.gameObject.GetComponent<Entity>().soldierType.Equals("Cthulhu"))
                {
                    int randomHitChance = Random.Range(0, 100);

                    if (randomHitChance > 35)
                    {
                        entityHit.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                        Destroy(gameObject);
                    }
                    else
                    {
                        rb.velocity = Vector2.zero;
                        animator.SetBool("Break", true);
                    }
                }
                else
                {
                    entityHit.GetComponent<Entity>().HP -= sourceEntity.GetComponent<Entity>().damage;
                    Destroy(gameObject);
                }
            }
        }
    }

    public void breakArrow()
    {
        Destroy(gameObject);
    }
}
