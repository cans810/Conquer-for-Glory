using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierContainerManager : MonoBehaviour
{

    public GameObject SoldierContained;

    public Image backgroundImage;

    public bool selected;

    public float timer;
    public bool canSummon;
    public string soldierRace;

    public void Awake(){
        timer = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soldierRace = SoldierContained.GetComponent<Entity>().race;
        
        timer += Time.deltaTime;

        float fillAmount = Mathf.Clamp01(timer / SoldierContained.GetComponent<Entity>().timeToSummon);

        if (backgroundImage != null)
        {
            backgroundImage.fillAmount = fillAmount;
        }

        if (fillAmount >= 1.0f)
        {
            canSummon = true;
        }

        if (selected){
            backgroundImage.color = Color.red;
        }

        else if (!selected){

            backgroundImage.color = Color.black;

        }
    }
}
