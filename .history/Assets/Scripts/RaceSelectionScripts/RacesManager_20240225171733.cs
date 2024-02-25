using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacesManager : MonoBehaviour
{

    public List<string> racesNames;

    public void Awake(){
        racesNames.Add("Human");
        racesNames.Add("Elf");
        racesNames.Add("Orc");
        racesNames.Add("Demon");
        racesNames.Add("Troll");
        racesNames.Add("EasternHuman");
        racesNames.Add("Wraith");
        racesNames.Add("SeaElf");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
