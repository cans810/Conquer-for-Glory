using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance; // Singleton instance

    public GameObject MapObject;

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            // If not, set this instance as the singleton instance
            Instance = this;
        }
        else
        {
            // If an instance already exists, destroy this instance
            // Ensures there's only one GameManager throughout the game
            Destroy(gameObject);
        }

        // Ensure this instance persists between scenes
        DontDestroyOnLoad(gameObject);

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
            if (cityInfo != null && cityInfo.cityRaceType.Contains(GameManager.Instance.PlayerRace))
            {
                cityInfo.isConqueredByPlayer = true;
                foreach (var neighbour in cityInfo.Neighbours)
                {
                    if (!GameManager.Instance.AllNeighbours.Contains(neighbour) && !neighbour.GetComponent<CityInfo>().cityName.Contains(GameManager.Instance.PlayerRace))
                    {
                        GameManager.Instance.AllNeighbours.Add(neighbour);
                    }
                }
            }
        }

        // eğer şehrin ismi bizim komşuların listesinde varsa o zaman canAttack true oluyor
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
            }
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
}
