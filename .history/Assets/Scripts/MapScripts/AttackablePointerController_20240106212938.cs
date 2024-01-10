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

    public void Awake(){
        popupInfo = GameObject.Find("PopupInfo");
        pointerImage = GameObject.Find("AttackablePointer");
    }
    void Start()
    {
        popupInfo.transform.localPosition = new Vector3(-1000,305,0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        popupInfo.transform.localPosition = new Vector3(-577,305,0);
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        popupInfo.transform.localPosition = new Vector3(-1000,305,0);
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
