using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCommonActions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void walk(string direction, float speed)
    {
        Vector3 moveDirection = Vector3.zero;

        switch (direction.ToLower())
        {
            case "right":
                moveDirection = transform.right;
                break;
            case "left":
                moveDirection = -transform.right;
                break;
            default:
                break;
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
    
    public void ChangeDirection(string direction)
    {
        int facingDirection = 1;

        if (direction.ToLower() == "left")
        {
            facingDirection = -1;
        }

        Vector3 currentScale = transform.localScale;

        transform.localScale = new Vector3(facingDirection * Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
    }

    public void burn()
    {
        float damageTaken = 5f;
        float duration = 2.0f;
        float initialHP = GetComponent<Entity>().HP;
        float targetHP = initialHP - damageTaken;

        StartCoroutine(BurnCoroutine(initialHP, targetHP, duration));
    }

    private IEnumerator BurnCoroutine(float startHP, float targetHP, float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            float currentHP = Mathf.Lerp(startHP, targetHP, timer / duration);
            GetComponent<Entity>().HP = currentHP;

            timer += Time.deltaTime;
            yield return null;
        }

        GetComponent<Entity>().HP = targetHP;
    }
}
