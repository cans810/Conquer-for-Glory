using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttackablePointerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovered = false;

    public string cityName;
    public string cityRaceType;
    public List<GameObject> soldiers;

    public GameObject popupInfo;
    public GameObject pointerImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isHovered){
            isHovered = true;
            UpdateUIVisibility();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        UpdateUIVisibility();
    }

    void UpdateUIVisibility()
    {
        if (isHovered)
        {
            popupInfo.SetActive(true);
            popupInfo.transform.Find("SelectedLandName").GetComponent<TextMeshProUGUI>().text = cityName;
            popupInfo.transform.Find("SelectedLandInfo").GetComponent<TextMeshProUGUI>().text = "Race: " + cityRaceType + "\n" + "Difficulty: ";
            ChangeAlpha(1f);
        }
        else
        {
            popupInfo.SetActive(false);
            ChangeAlpha(0.5f);
        }
    }

    public void ChangeAlpha(float alphaValue)
    {
        Color color = pointerImage.GetComponent<Image>().color;
        color.a = alphaValue;
        pointerImage.GetComponent<Image>().color = color;
    }

    private void OnMouseDown()
    {
        GameManager.Instance.CurrentEnemyName = cityName;
        GameManager.Instance.CurrentEnemyRace = cityRaceType;
        GameManager.Instance.CurrentEnemySoldiers = soldiers;

        SceneManager.LoadScene("BattleScene");
    }
}

