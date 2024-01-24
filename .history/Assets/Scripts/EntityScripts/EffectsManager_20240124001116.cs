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

        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Elf"){
            
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "EasternHuman"){
            
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Troll"){
            
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Demon"){
            
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Wraith"){
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBloodColor(){

    }
}
