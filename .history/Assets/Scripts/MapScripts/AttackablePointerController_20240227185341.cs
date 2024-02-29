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
    public GameObject tipPoint;

    public string cityName;
    public string cityRaceType;
    public List<GameObject> soldiers;
    public string difficulty;

    public GameObject popupInfo;
    public GameObject pointerImage;

    public void OnMouseEnter()
    {
        isHovered = true;
        popupInfo.transform.SetParent(GameObject.Find("Map").transform);
    }

    public void OnMouseExit()
    {
        isHovered = false;
        popupInfo.transform.SetParent(parentLand.transform);
    }

    public void Update()
    {
        if (SettingsManager.Instance.settingsTab.activeSelf)
        if (isHovered)
        {
            popupInfo.SetActive(true);
            popupInfo.transform.position = tipPoint.transform.position;
            popupInfo.transform.Find("SelectedLandName").GetComponent<TextMeshProUGUI>().text = cityName;
            popupInfo.transform.Find("SelectedLandInfo").GetComponent<TextMeshProUGUI>().text = "Race: " + cityRaceType + "\n" + "Difficulty: " + difficulty;
            ChangeAlpha(1f);
        }
        else
        {
            popupInfo.SetActive(false);
            ChangeAlpha(0.6f);
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
