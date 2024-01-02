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
        // Find the head GameObject in the scene
        head = GameObject.Find("Head"); // Replace "Head" with the actual name of your head GameObject

        if (head != null)
        {
            // Get the position of the head
            Vector3 headPosition = head.transform.position;

            // Create a new GameObject using the head
            GameObject detachedHead = new GameObject("DetachedHead");
            detachedHead.transform.position = headPosition;

            // Add a Rigidbody2D component to the detached head
            Rigidbody2D rb = detachedHead.AddComponent<Rigidbody2D>();

            // Launch the detached head a little bit upwards
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);

            // Deactivate the original head
            head.SetActive(false);
        }
        else
        {
            Debug.LogError("Head not found!");
        }
    }
}
