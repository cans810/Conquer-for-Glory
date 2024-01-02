using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachedHeadController : MonoBehaviour
{
    private Vector3 originalPosition;
    private bool shouldDestroy = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Check if the head's Y position is less than the original Y position
        if (transform.position.y < originalPosition.y && !shouldDestroy)
        {
            // Stop further movement by removing the Rigidbody2D component
            Destroy(GetComponent<Rigidbody2D>());

            // Set the flag to start the countdown for destruction
            shouldDestroy = true;

            // Start the countdown to destroy after 3 seconds
            StartCoroutine(DestroyAfterDelay(3f));
        }
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Destroy the detached head after the delay
        Destroy(gameObject);
    }
}