using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CityInfo : MonoBehaviour
{
    public bool isConqueredByPlayer;
    public string cityName;
    public string cityRaceType;
    public string difficulty;

    public GameObject imageObject;
    public List<GameObject> Soldiers;

    public List<GameObject> Neighbours;

    public bool canAttack;
    public GameObject attackablePointerPrefab;

    // Start is called before the first frame update
    void Start()
    {
        if (isConqueredByPlayer){
            cityName = "You";
            cityRaceType = GameManager.Instance.PlayerRace;

            GameManager.Instance.playerLandColor = imageObject.GetComponent<SpriteRenderer>().color;
        }
        else{
            if (!canAttack){

            }
            if (canAttack) {
                GameObject attackablePointer = Instantiate(attackablePointerPrefab, gameObject.transform.position, Quaternion.identity);
                attackablePointer.transform.SetParent(gameObject.transform);
                attackablePointer.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                GameObject imageObject = attackablePointer.transform.Find("AttackablePointer").gameObject;
                GameObject popupObject = attackablePointer.transform.Find("PopupInfo").gameObject;
                
                foreach (GameObject neighbour in Neighbours) {
                    if (neighbour != null && neighbour.GetComponent<CityInfo>().isConqueredByPlayer) {

                        Vector3 direction = neighbour.transform.position - gameObject.transform.position;
                        float distance = direction.magnitude;

                        imageObject.transform.localScale = new Vector3(distance/6f, 0.5f, 0.5f);

                        Vector3 midpoint = (gameObject.transform.position + neighbour.transform.position) / 2f;
                        imageObject.transform.position = midpoint;
                        popupObject.transform.position = midpoint;

                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        imageObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                        imageObject.GetComponent<AttackablePointerController>().cityName = cityName;
                        imageObject.GetComponent<AttackablePointerController>().cityRaceType = cityRaceType;
                        imageObject.GetComponent<AttackablePointerController>().soldiers = Soldiers;
                    }
                }
            }


        }
    }

    public void enterBattle(){
        GameManager.Instance.CurrentEnemyName = cityName;
        GameManager.Instance.CurrentEnemyRace = cityRaceType;

        GameManager.Instance.CurrentEnemySoldiers = Soldiers;

        SceneManager.LoadScene("BattleScene");
    }
}
