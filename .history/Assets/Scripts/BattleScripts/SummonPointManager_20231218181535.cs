using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonPointManager : MonoBehaviour
{

    public bool selected;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selected){
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
            GetComponent<SpriteRenderer>().color.g,GetComponent<SpriteRenderer>().color.b,1f);
        }
        else{
            GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r,
            GetComponent<SpriteRenderer>().color.g,GetComponent<SpriteRenderer>().color.b,0f);
        }
    }
}
