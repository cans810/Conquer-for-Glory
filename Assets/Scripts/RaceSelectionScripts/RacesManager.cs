using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacesManager : MonoBehaviour
{

    public List<string> racesNames;

    public void Awake(){
        racesNames.Add("human");
        racesNames.Add("elf");
        racesNames.Add("orc");
        racesNames.Add("goblin");
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
