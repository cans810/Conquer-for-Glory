using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachEntityParts : MonoBehaviour
{
    GameObject head;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void detachHead()
    {
        // Search for the "Head" object among the children of this GameObject
        Transform foundHead = transform.Find("Head");

        if (foundHead != null)
        {
            // Get the position of the found head
            Vector3 headPosition = foundHead.position;

            // Create a new GameObject using the found head's position
            GameObject detachedHead = new GameObject("DetachedHead");
            detachedHead.transform.position = headPosition;

            // Add a Rigidbody2D component to the detached head
            Rigidbody2D rb = detachedHead.AddComponent<Rigidbody2D>();

            // Launch the detached head a little bit upwards
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);

            // Deactivate the original head
            foundHead.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Head not found among children!");
        }
    }
}
