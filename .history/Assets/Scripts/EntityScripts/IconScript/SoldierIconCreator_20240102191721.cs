using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SoldierIconCreator : MonoBehaviour
{
    private GameObject soldierPrefab; // Reference to the soldier prefab
    public GameObject soldierIconObject; // Reference to the GameObject to hold the soldier icon

    public void GenerateIcon()
    {
        soldierPrefab = gameObject.GetComponent<SoldierContainerManager>().SoldierContained;

        GameObject newSoldierIcon = Instantiate(soldierPrefab, soldierIconObject.transform.position, Quaternion.identity);
        
        newSoldierIcon.transform.SetParent(soldierIconObject.transform);

        // Get all components attached to the newly instantiated object
        Component[] components = newSoldierIcon.GetComponents<Component>();

        // Remove unnecessary components
        foreach (Component comp in components)
        {
            if (!(comp is SpriteLibrary) && !(comp is Rigidbody2D) && !(comp is Transform))
            {
                Destroy(comp);
            }
        }

        // Find and destroy the "HitBox" child GameObject
        Transform hitBoxChild = newSoldierIcon.transform.Find("HitBox");
        if (hitBoxChild != null)
        {
            Destroy(hitBoxChild.gameObject);
        }

        // Adjust the position to the right and down
        Vector3 newPosition = newSoldierIcon.transform.localPosition;
        newPosition += new Vector3(1f, -1f, 0f); // Adjust the values as needed
        newSoldierIcon.transform.localPosition = newPosition;
    }
}
