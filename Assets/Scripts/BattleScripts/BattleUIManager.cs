using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winBattle(){
        GameManager.Instance.AllConqueredCityNames.Add(GameManager.Instance.CurrentEnemyName);

        SceneManager.LoadScene("MapScene");
    }
}
