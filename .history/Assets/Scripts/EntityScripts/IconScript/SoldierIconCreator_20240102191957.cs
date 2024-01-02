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

        Component[] components = newSoldierIcon.GetComponents<Component>();

        foreach (Component comp in components)
        {
            if (!(comp is SpriteLibrary) && !(comp is Rigidbody2D) && !(comp is Transform))
            {
                Destroy(comp);
            }
        }

        Transform hitBoxChild = newSoldierIcon.transform.Find("HitBox");
        if (hitBoxChild != null)
        {
            Destroy(hitBoxChild.gameObject);
        }

        Vector3 newPosition = newSoldierIcon.transform.localPosition;
        newPosition += new Vector3(50f, -100f, 0f);
        newSoldierIcon.transform.localPosition = newPosition;
    }
}
