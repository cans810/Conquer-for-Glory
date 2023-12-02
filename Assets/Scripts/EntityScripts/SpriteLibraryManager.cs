using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class SpriteLibraryManager : MonoBehaviour
{

    public List<SpriteLibraryAsset> RaceModels;

    public void Awake(){

        if (gameObject.GetComponent<Entity>().race.Equals("Human")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[0];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Elf")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[1];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Demon")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[2];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Orc")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[3];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Troll")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[4];
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Entity>().race.Equals("Human")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[0];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Elf")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[1];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Demon")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[2];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Orc")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[3];
        }
        else if (gameObject.GetComponent<Entity>().race.Equals("Troll")){
            gameObject.GetComponent<SpriteLibrary>().spriteLibraryAsset = RaceModels[4];
        }
    }
}
