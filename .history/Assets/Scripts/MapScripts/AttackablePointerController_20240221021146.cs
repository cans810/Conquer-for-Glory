using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttackablePointerController : MonoBehaviour
{
    bool isHovered = false;

    public GameObject parentLand;

    public string cityName;
    public string cityRaceType;
    public List<GameObject> soldiers;
    public string difficulty;

    public GameObject popupInfo;
    public GameObject pointerImage;

    public void OnMouseEnter()
    {
        transform.SetParent(null);
        isHovered = true;
    }

    public void OnMouseExit()
    {
        transform.SetParent(parentLand);
        isHovered = false;
    }

    public void Update()
    {
        if (isHovered)
        {
            popupInfo.SetActive(true);
            popupInfo.transform.Find("SelectedLandName").GetComponent<TextMeshProUGUI>().text = cityName;
            popupInfo.transform.Find("SelectedLandInfo").GetComponent<TextMeshProUGUI>().text = "Race: " + cityRaceType + "\n" + "Difficulty: " + difficulty;
            ChangeAlpha(1f);
        }
        else
        {
            popupInfo.SetActive(false);
            ChangeAlpha(0.7f);
        }
    }

    public void ChangeAlpha(float alphaValue)
    {
        Color color = pointerImage.GetComponent<SpriteRenderer>().color;
        color.a = alphaValue;
        pointerImage.GetComponent<SpriteRenderer>().color = color;
    }

    private void OnMouseDown()
    {
        GameManager.Instance.CurrentEnemyName = cityName;
        GameManager.Instance.CurrentEnemyRace = cityRaceType;

        GameManager.Instance.CurrentEnemySoldiers = soldiers;

        SceneManager.LoadScene("BattleScene");
    }
}
