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
            bloodColor = new Color(198,0,0);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Elf"){
            bloodColor = new Color(198,0,0);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "EasternHuman"){
            bloodColor = new Color(198,0,0);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Orc"){
            bloodColor = new Color(0,41,145);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Troll"){
            bloodColor = new Color(60,122,73);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Demon"){
            bloodColor = new Color(43,2,0);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Wraith"){
            bloodColor = new Color(70,79,113);
            bloodColor.a = 0;
        }
    }
}
