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

            SpriteRenderer detachedRenderer = detachedHead.AddComponent<SpriteRenderer>();

            SpriteRenderer originalRenderer = foundHead.GetComponent<SpriteRenderer>();

            if (originalRenderer != null)
            {
                detachedRenderer.sprite = originalRenderer.sprite;

                detachedHead.transform.localScale = Vector3.one;
                detachedHead.transform.localScale = foundHead.lossyScale;

                float randomAngle = Random.Range(-15f, 15f);

                Vector2 launchDirection = Quaternion.Euler(0, 0, randomAngle) * Vector2.up;
                Rigidbody2D rb = detachedHead.AddComponent<Rigidbody2D>();
                rb.AddForce(launchDirection * 2f, ForceMode2D.Impulse);

                rb.angularVelocity = 100f;
            }

            foundHead.gameObject.SetActive(false);
        }
    }


}
