using UnityEngine;

public class SoldierIconCreator : MonoBehaviour
{
    public GameObject newSoldierPrefab; // Reference to the prefab to be instantiated

    void Start()
    {
        CreateNewSoldier();
    }

    void CreateNewSoldier()
    {
        // Get the appearance from SoldierContainerManager's SoldierContained
        SpriteRenderer[] bodyParts = GetComponent<SoldierContainerManager>().bodyParts;

        // Instantiate the new soldier prefab
        GameObject newSoldier = Instantiate(newSoldierPrefab, transform.position, Quaternion.identity);

        // Access the SpriteRenderers in the new soldier and set their sprites based on bodyParts
        SpriteRenderer[] newSoldierBodyParts = newSoldier.GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < Mathf.Min(bodyParts.Length, newSoldierBodyParts.Length); i++)
        {
            newSoldierBodyParts[i].sprite = bodyParts[i].sprite;
            // Optionally, you might also want to copy other properties like sorting order, color, etc.
            // newSoldierBodyParts[i].sortingOrder = bodyParts[i].sortingOrder;
            // newSoldierBodyParts[i].color = bodyParts[i].color;
            // ... (copy other necessary properties)
        }
    }
}
