using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public Color bloodColor;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Human"){
            bloodColor = Color.red;
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Elf"){
            bloodColor = Color.red;
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "EasternHuman"){
            bloodColor = Color.red;
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Orc"){
            bloodColor = new Color(0,20,140);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Troll"){
            bloodColor = Color.red;
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Demon"){
            bloodColor = Color.red;
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Wraith"){
            bloodColor = Color.red;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
