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
        // Convert the direction string to a Vector3 direction
        Vector3 moveDirection = Vector3.zero;

        // Set the move direction based on the input direction string
        switch (direction.ToLower())
        {
            case "right":
                moveDirection = transform.right;
                break;
            case "left":
                moveDirection = -transform.right;
                break;
            default:
                Debug.LogWarning("Invalid direction input");
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
        else if (direction.ToLower() != "right")
        {
            Debug.LogWarning("Invalid direction input. Defaulting to 'right'.");
        }

        // Get the current scale of the GameObject
        Vector3 currentScale = transform.localScale;

        // Set the scale to flip the GameObject horizontally
        transform.localScale = new Vector3(facingDirection * Mathf.Abs(currentScale.x), currentScale.y, currentScale.z);
    }
}
