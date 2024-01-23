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

    public void burn(float damageTaken)
    {
        
    }
}
