using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketUIAnims : MonoBehaviour
{

    public void setDeactive(){
        gameObject.GetComponent<Animator>().SetBool("ShowError",false);
    }
}
