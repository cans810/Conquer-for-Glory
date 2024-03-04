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
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        entityComponent = sourceEntity.GetComponent<Entity>();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity entityHit = collision.gameObject.GetComponent<Entity>();
        
        if (sourceEntity.tag.Equals("Player"))
        {
            if (collision.CompareTag("Enemy") && spawnedAtRow == entityHit.spawnedAtRow)
            {
                if (!entityHit.soldierType.Equals("TrollGiant") && !entityHit.soldierType.Equals("EasternLion")
                && !entityHit.soldierType.Equals("MountedSpearman")
                && !entityHit.soldierType.Equals("Minotaur") && !entityHit.soldierType.Equals("OrcBeast")
                && !entityHit.soldierType.Equals("Dragon") && !entityHit.soldierType.Equals("Cthulhu") && !entityHit.soldierType.Equals("Mammoth"))
                {
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                if (entityHit.soldierType.Equals("TrollGiant")
                || entityHit.soldierType.Equals("Minotaur") || entityHit.soldierType.Equals("OrcBeast")
                || entityHit.soldierType.Equals("Dragon") || entityHit.soldierType.Equals("Cthulhu") entityHit.soldierType.Equals("Mammoth"))
                {
                    int randomHitChance = Random.Range(0, 100);

                    if (randomHitChance > 35)
                    {
                        entityHit.HP -= entityComponent.damage;
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
                    entityHit.HP -= entityComponent.damage;
                    Destroy(gameObject);
                }

                Destroy(gameObject);
            }
        }
        else if (sourceEntity.tag.Equals("Enemy"))
        {
            if (collision.CompareTag("Player") && spawnedAtRow == entityHit.spawnedAtRow)
            {
                if (!entityHit.soldierType.Equals("TrollGiant") && !entityHit.soldierType.Equals("EasternLion")
                && !entityHit.soldierType.Equals("MountedSpearman")
                && !entityHit.soldierType.Equals("Minotaur") && !entityHit.soldierType.Equals("OrcBeast")
                && !entityHit.soldierType.Equals("Dragon") && !entityHit.soldierType.Equals("Cthulhu") && !entityHit.soldierType.Equals("Mammoth"))
                {
                    collision.gameObject.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playHurtSound();
                }

                if (entityHit.soldierType.Equals("TrollGiant")
                || entityHit.soldierType.Equals("Minotaur") || entityHit.soldierType.Equals("OrcBeast")
                || entityHit.soldierType.Equals("Dragon") || entityHit.soldierType.Equals("Cthulhu") && !entityHit.soldierType.Equals("Mammoth"))
                {
                    int randomHitChance = Random.Range(0, 100);

                    if (randomHitChance > 35)
                    {
                        entityHit.HP -= entityComponent.damage;
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
                    entityHit.HP -= entityComponent.damage;
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
