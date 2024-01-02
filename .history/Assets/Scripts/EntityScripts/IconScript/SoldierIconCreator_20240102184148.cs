using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierIconCreator : MonoBehaviour
{
    public SpriteRenderer[] bodyParts; // Assign the sprite renderers of body parts in the Inspector
    public Vector2 iconSize = new Vector2(100, 100); // Define the icon size

    public void Start(){
        
        // Assuming the SoldierContained object is a child of the SoldierContainerManager
        // Access its children and find those with a SpriteRenderer component
        SpriteRenderer[] childRenderers = gameObject.GetComponent<SoldierContainerManager>().SoldierContained.GetComponentsInChildren<SpriteRenderer>();

        // Filter only the SpriteRenderer components that are direct children of SoldierContained
        bodyParts = FilterChildRenderers(childRenderers, gameObject.GetComponent<SoldierContainerManager>().SoldierContained.transform);
    }

    public Sprite CreateIcon()
    {
        // Create a new texture to compose the icon
        Texture2D iconTexture = new Texture2D((int)iconSize.x, (int)iconSize.y);

        // Loop through each body part and copy its texture into the icon
        foreach (SpriteRenderer bodyPartRenderer in bodyParts)
        {
            Sprite bodyPartSprite = bodyPartRenderer.sprite;
            Texture2D bodyPartTexture = bodyPartSprite.texture;

            // Calculate the position on the icon where this body part should be placed
            Vector2 position = /* Calculate the position based on the body part's position */

            // Copy the pixels from the body part texture to the icon texture
            for (int x = 0; x < bodyPartSprite.texture.width; x++)
            {
                for (int y = 0; y < bodyPartSprite.texture.height; y++)
                {
                    Color pixel = bodyPartTexture.GetPixel(x, y);
                    iconTexture.SetPixel((int)position.x + x, (int)position.y + y, pixel);
                }
            }
        }

        // Apply changes to the icon texture and create a sprite from it
        iconTexture.Apply();
        Rect rect = new Rect(0, 0, iconTexture.width, iconTexture.height);
        return Sprite.Create(iconTexture, rect, Vector2.one * 0.5f);
    }

    SpriteRenderer[] FilterChildRenderers(SpriteRenderer[] renderers, Transform parent)
    {
        // Filter the renderers to only include those that are direct children of the parent
        System.Collections.Generic.List<SpriteRenderer> filteredRenderers = new System.Collections.Generic.List<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            if (renderer.transform.parent == parent)
            {
                filteredRenderers.Add(renderer);
            }
        }

        return filteredRenderers.ToArray();
    }
}

