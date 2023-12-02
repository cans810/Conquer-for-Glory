using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

        checkIfPlayerWonAndConquerCity();

        Transform parentTransform = MapObject.transform;

        foreach (Transform child in parentTransform)
        {
            CityInfo cityInfo = child.gameObject.GetComponent<CityInfo>();
            if (cityInfo != null && cityInfo.cityRaceType.Contains(GameManager.Instance.PlayerRace))
            {
                cityInfo.isConqueredByPlayer = true;
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
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name.Equals("MapScene")){

        }
    }
}
