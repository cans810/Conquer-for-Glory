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
        detachedHead.transform.localScale = foundHead.transform.localScale;

        // Add SpriteRenderer component to the detached head
        SpriteRenderer detachedRenderer = detachedHead.AddComponent<SpriteRenderer>();

        // Get the SpriteRenderer from the original head
        SpriteRenderer originalRenderer = foundHead.GetComponent<SpriteRenderer>();

        if (originalRenderer != null)
        {
            // Set the sprite of the detached SpriteRenderer to match the original
            detachedRenderer.sprite = originalRenderer.sprite;
        }
        else
        {
            Debug.LogWarning("SpriteRenderer not found on original head!");
        }

        // Deactivate the original head
        foundHead.gameObject.SetActive(false);

        Rigidbody2D rb = detachedHead.AddComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * 1.5f, ForceMode2D.Impulse);
    }
    else
    {
        Debug.LogError("Head not found among children!");
    }
}
}
