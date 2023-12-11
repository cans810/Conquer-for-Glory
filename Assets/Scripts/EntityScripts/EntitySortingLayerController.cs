using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySortingLayerController : MonoBehaviour
{
    void Start()
    {
        SetSortingLayer(transform);
    }

    void SetSortingLayer(Transform parent)
    {
        foreach (Transform child in parent)
        {
            SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.sortingLayerName = gameObject.GetComponent<Entity>().spawnedAtRow.ToString();
            }

            // Recursive call to handle child's children
            SetSortingLayer(child);
        }
    }
}
