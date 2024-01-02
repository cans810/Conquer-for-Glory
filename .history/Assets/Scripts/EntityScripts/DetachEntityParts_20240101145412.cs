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

            GameObject detachedHead = Instantiate(foundHead.gameObject, headPosition, Quaternion.identity);
            detachedHead.name = "DetachedHead";

            detachedHead.transform.position = headPosition;
            
            foundHead.gameObject.SetActive(false);

            Rigidbody2D rb = detachedHead.AddComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * 1f, ForceMode2D.Impulse);

        }
        else
        {
            Debug.LogError("head not found");
        }
    }
}
