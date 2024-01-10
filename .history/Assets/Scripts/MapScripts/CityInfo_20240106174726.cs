using System.Collections;
using System.Collections.Generic;
using TMPro;
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
            if (canAttack){
                // attack pointer instantiation ve rotation/scaling ayarlamaları
                GameObject attackablePointer = Instantiate(attackablePointerPrefab, gameObject.transform.position, Quaternion.identity);
                attackablePointer.transform.SetParent(gameObject.transform);
                attackablePointer.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

                foreach (GameObject neighbour in Neighbours) {
                    if (neighbour != null && neighbour.GetComponent<CityInfo>().isConqueredByPlayer) {
                        Vector3 direction = neighbour.transform.position - gameObject.transform.position;
                        float distance = direction.magnitude; // Calculate the distance between the current position and the neighbor
                        
                        attackablePointer = Instantiate(attackablePointerPrefab, gameObject.transform.position, Quaternion.identity);
                        attackablePointer.transform.SetParent(gameObject.transform);
                        attackablePointer.transform.localScale = new Vector3(distance, 1f, 1f); // Set length based on distance
                        attackablePointer.transform.position = gameObject.transform.position + direction / 2f; // Move to the midpoint
                        
                        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                        attackablePointer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                        attackablePointer.GetComponent<AttackablePointerController>().cityName = cityName;
                        attackablePointer.GetComponent<AttackablePointerController>().cityRaceType = cityRaceType;
                        attackablePointer.GetComponent<AttackablePointerController>().soldiers = Soldiers;

                        attackablePointer.transform.Find("PopupInfo").transform.rotation = Quaternion.Euler(0, 0, 0);
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
