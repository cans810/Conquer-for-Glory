using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public Color bloodColor;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Human")
        {
            bloodColor = new Color(198 / 255f, 0, 0);
        }
        else if(gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Elf"){
            bloodColor = new Color(198 / 255f, 0, 0);
        }
        else if(gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "EasternHuman"){
            bloodColor = new Color(198 / 255f, 0, 0);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Orc")
        {
            bloodColor = new Color(4 / 255f, 0 / 255f, 113 / 255f);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Troll")
        {
            bloodColor = new Color(60 / 255f, 122 / 255f, 73 / 255f);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Demon")
        {
            bloodColor = new Color(43 / 255f, 2 / 255f, 0);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "Wraith")
        {
            bloodColor = new Color(70 / 255f, 79 / 255f, 113 / 255f, 0);
        }
        else if (gameObject.transform.parent.gameObject.GetComponent<Entity>().race == "SeaElf")
        {
            bloodColor = new Color(4 / 255f, 0 / 255f, 113 / 255f);
        }
    }
}
