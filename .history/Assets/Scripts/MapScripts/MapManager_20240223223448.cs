using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{

    public GameObject MapObject;

    private Camera mainCamera;
    public bool viewingEast;

    public GameObject ScreenFade;

    private void Awake()
    {


        if (SceneManager.GetActiveScene().name.Equals("MapScene")){
            MapObject = GameObject.Find("Map");
        }

        // baştan temiz listeyi doldurmak için önce clear
        GameManager.Instance.AllNeighbours.Clear();

        // tüm haritayı iterate edip eğer şehrin ismi conquer edilen şehirler listesinde varsa o zaman isconquered true ve race'i de oyuncunun race i yapıyor.
        checkIfPlayerWonAndConquerCity();

        Transform parentTransform = MapObject.transform;

        // conquer edilen tüm şehirlerin neighbourlarını alıp oyuncunun neighbour listesine atıyor
        foreach (Transform child in parentTransform)
        {
            CityInfo cityInfo = child.gameObject.GetComponent<CityInfo>();
            if (cityInfo != null && cityInfo.cityRaceType.Equals(GameManager.Instance.PlayerRace))
            {
                cityInfo.isConqueredByPlayer = true;
                foreach (var neighbour in cityInfo.Neighbours)
                {
                    if (!GameManager.Instance.AllNeighbours.Contains(neighbour) && !neighbour.GetComponent<CityInfo>().cityName.Equals(GameManager.Instance.PlayerRace))
                    {
                        GameManager.Instance.AllNeighbours.Add(neighbour);
                    }
                }
            }
        }

        // tüm haritayı iterate edip eğer şehrin ismi bizim komşuların listesinde varsa o zaman canAttack true oluyor
        foreach (Transform child in parentTransform)
        {
            CityInfo cityInfo = child.gameObject.GetComponent<CityInfo>();
            if (cityInfo != null)
            {
                foreach(GameObject city in GameManager.Instance.AllNeighbours){
                    if (city != null){
                        if (cityInfo.cityName.Equals(city.GetComponent<CityInfo>().cityName)){
                            cityInfo.canAttack = true;
                        }
                    }
                }
            }
        }
    }

    public void checkIfPlayerWonAndConquerCity(){

        Transform parentTransform = MapObject.transform;

        foreach (Transform child in parentTransform)
        {
            CityInfo cityInfo = child.gameObject.GetComponent<CityInfo>();

            foreach(string conqueredCityName in GameManager.Instance.AllConqueredCityNames){
                if (cityInfo != null && cityInfo.cityName.Equals(conqueredCityName))
                {
                    cityInfo.isConqueredByPlayer = true;
                    cityInfo.cityRaceType = GameManager.Instance.PlayerRace;
                    cityInfo.imageObject.GetComponent<SpriteRenderer>().color = GameManager.Instance.playerLandColor;
                }
            }
        }

        // battle bittiği için bunları sıfırlıyor
        GameManager.Instance.CurrentEnemyName = "";
        GameManager.Instance.CurrentEnemyRace = "";
        GameManager.Instance.CurrentEnemySoldiers = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("MapScene")){
            MapObject = GameObject.Find("Map");

            if(isEveryLandConquered()){
                GameManager.Instance.allLandsConquered = true;
                ScreenFade.GetComponent<Animator>().SetBool("FadeOut")
                SceneManager.LoadScene("GameOverScene");
            }

            mainCamera = Camera.main;
        }
    }

    public bool isEveryLandConquered(){
        MapObject = GameObject.Find("Map");
        Transform parentTransform = MapObject.transform;

        foreach (Transform child in parentTransform)
        {
            if (child != null){
                CityInfo cityInfo = child.gameObject.GetComponent<CityInfo>();
                if (cityInfo != null)
                {
                    if (!cityInfo.isConqueredByPlayer){
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public void viewEast(){
        if (!viewingEast){
            viewingEast = true;
            mainCamera.GetComponent<Animator>().SetTrigger("ViewEast_camera");
        }
    }

    public void viewWest(){
        if (viewingEast){
            viewingEast = false;
            mainCamera.GetComponent<Animator>().SetTrigger("ViewNormal_camera");
        }
    }
}
