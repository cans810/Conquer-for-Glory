using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SoldierIconCreator : MonoBehaviour
{
    private GameObject soldierContained;
    public GameObject soldierIconObject;

    public void GenerateIconPlayerSide()
    {
        soldierContained = gameObject.GetComponent<SoldierContainerManager>().SoldierContained;

        GameObject newSoldierIcon = Instantiate(soldierContained, soldierIconObject.transform.position, Quaternion.identity);
        
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

        if (soldierContained.GetComponent<Entity>().soldierType == "Mammoth"){
            newPosition += new Vector3(30f, -30f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "EasternLion"){
            newPosition += new Vector3(4f, -65f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "TrollGiant"){
            newPosition += new Vector3(24f, -24f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "Dragon"){
            newPosition += new Vector3(10f, -60f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "OrcBeast"){
            newPosition += new Vector3(19f, -23f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "MountedSpearMan"){
            newPosition += new Vector3(10f, -30f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else{
            newPosition += new Vector3(10f, -14f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
    }

    public void GenerateIconEnemySide()
    {
        soldierContained = gameObject.GetComponent<SoldierContainerManager>().SoldierContained;

        GameObject newSoldierIcon = Instantiate(soldierContained, soldierIconObject.transform.position, Quaternion.identity);
        
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

        if (soldierContained.GetComponent<Entity>().soldierType == "Mammoth"){
            newPosition += new Vector3(-30f, -30f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "EasternLion"){
            newPosition += new Vector3(-4f, -65f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "TrollGiant"){
            newPosition += new Vector3(-24f, -24f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "Dragon"){
            newPosition += new Vector3(-10f, -60f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "OrcBeast"){
            newPosition += new Vector3(-19f, -23f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else if(soldierContained.GetComponent<Entity>().soldierType == "MountedSpearMan"){
            newPosition += new Vector3(-10f, -30f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }
        else{
            newPosition += new Vector3(-10f, -14f, 0f);
            newSoldierIcon.transform.localPosition = newPosition;
        }

        Vector3 currentScale = newSoldierIcon.transform.localScale;
        newSoldierIcon.transform.localScale = new Vector3(currentScale.x * -1f, currentScale.y, currentScale.z);
    }


}
