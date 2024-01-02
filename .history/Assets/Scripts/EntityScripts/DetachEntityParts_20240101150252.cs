using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachEntityParts : MonoBehaviour
{
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
        Transform foundHead = transform.Find("Head");

        if (foundHead != null)
        {
            Vector3 headPosition = foundHead.position;

            GameObject detachedHead = new GameObject("DetachedHead");
            detachedHead.transform.position = headPosition;

            // Add SpriteRenderer component to the detached head
            SpriteRenderer detachedRenderer = detachedHead.AddComponent<SpriteRenderer>();

            // Get the SpriteRenderer from the original head
            SpriteRenderer originalRenderer = foundHead.GetComponent<SpriteRenderer>();

            if (originalRenderer != null)
            {
                // Set the sprite of the detached SpriteRenderer to match the original
                detachedRenderer.sprite = originalRenderer.sprite;

                // Set the scale of the detached head to match the original head
                detachedHead.transform.localScale = Vector3.one;
                detachedHead.transform.localScale = foundHead.lossyScale;

                // Generate a random angle between -15 and 15 degrees
                float randomAngle = Random.Range(-15f, 15f);

                // Apply a force with a slight random angle
                Vector2 launchDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
                Rigidbody2D rb = detachedHead.AddComponent<Rigidbody2D>();
                rb.AddForce(launchDirection * 1f, ForceMode2D.Impulse); // Adjust force magnitude as needed
            }
            else
            {
                Debug.LogWarning("SpriteRenderer not found on original head!");
            }

            // Deactivate the original head
            foundHead.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Head not found among children!");
        }
    }


}
