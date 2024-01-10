using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttackablePointerController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool isHovered = false;
    Image imageComponent;

    public string cityName;
    public string cityRaceType;
    public List<GameObject> soldiers;

    public GameObject popupInfo;

    void Start()
    {
        popupInfo = GameObject.Find("PopupInfo");
        imageComponent = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        popupInfo.SetActive(true);
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        popupInfo.SetActive(false);
        isHovered = false;
    }

    public void Update()
    {
        if (isHovered)
        {
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
        Color color = imageComponent.color;
        color.a = alphaValue;
        imageComponent.color = color;
    }

    private void OnMouseDown()
    {
        GameManager.Instance.CurrentEnemyName = cityName;
        GameManager.Instance.CurrentEnemyRace = cityRaceType;

        GameManager.Instance.CurrentEnemySoldiers = soldiers;

        SceneManager.LoadScene("BattleScene");
    }
}
