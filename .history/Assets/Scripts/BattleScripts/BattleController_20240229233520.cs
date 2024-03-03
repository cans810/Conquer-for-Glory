using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleController : MonoBehaviour
{
    //public GameObject BattleGround;
    public GameObject PlayerSummonPoints;
    public GameObject PlayerSoldierContainers;
    public int currentSelectedSummonPoint;
    public int currentSelectedSoldierContainer;

    public float playerProgress;

    public bool playerWon;
    public bool playerLost;
    public bool battleEnded;
    
    public int enemyDeathCounterUlti;
    public int playerDeathCounterUlti;
    public int enemyDeathCounterCoin;

    public GameObject pressQText;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    public void Awake(){
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        pressQText.SetActive(false);
        Transform parentTransformSoldierContainers = PlayerSoldierContainers.transform;
        parentTransformSoldierContainers.gameObject.GetComponent<PlayerSideSoldierContainersManager>().initContainers();

        currentSelectedSummonPoint = 0;
        currentSelectedSoldierContainer = 0;

        Transform parentTransformSummonPoints = PlayerSummonPoints.transform;
        parentTransformSummonPoints.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = true;
        parentTransformSoldierContainers.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = true;

        playerProgress = 50;
        enemyDeathCounterCoin = 0;

        playerWon = false;
        playerLost = false;
        battleEnded = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!battleEnded){
            if (Input.GetKeyDown(KeyCode.UpArrow) && !SettingsManager.Instance.battlePaused)
            {
                if (currentSelectedSummonPoint-1 >= 0){
                    Transform parentTransform = PlayerSummonPoints.transform;
                    parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = false;

                    currentSelectedSummonPoint--;
                    
                    parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && !SettingsManager.Instance.battlePaused)
            {
                if (currentSelectedSummonPoint+1 <= 7){
                    Transform parentTransform = PlayerSummonPoints.transform;
                    parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = false;

                    currentSelectedSummonPoint++;
                    
                    parentTransform.GetChild(currentSelectedSummonPoint).GetComponent<SummonPointManager>().selected = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && !SettingsManager.Instance.battlePaused)
            {
                if (currentSelectedSoldierContainer - 1 >= 0)
                {
                    Transform parentTransform = PlayerSoldierContainers.transform;
                    parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = false;

                    currentSelectedSoldierContainer--;

                    parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && !SettingsManager.Instance.battlePaused)
            {
                if (currentSelectedSoldierContainer + 1 < GameManager.Instance.PlayerSoldiers.Count)
                {
                    Transform parentTransform = PlayerSoldierContainers.transform;
                    parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = false;

                    currentSelectedSoldierContainer++;

                    parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().selected = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) || SettingsManager.Instance.autoSummon && enemyDeathCounterUlti < 20 && !SettingsManager.Instance.battlePaused)
            {
                Transform parentTransform = PlayerSoldierContainers.transform;

                if (parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().canSummon){
                    Transform transformSummonPoint = PlayerSummonPoints.transform;

                    Transform summonPoint = transformSummonPoint.GetChild(currentSelectedSummonPoint);

                    float summonPointHeight = summonPoint.GetComponent<Renderer>().bounds.size.y;

                    float randomXOffset = Random.Range(0f,0.2f);

                    Vector3 spawnPosition = summonPoint.position - new Vector3(0.8f + randomXOffset, summonPointHeight / 3f, 0);

                    GameObject playerSoldier = Instantiate(
                        parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().SoldierContained,
                        spawnPosition,
                        Quaternion.identity);

                    playerSoldier.tag = "Player";
                    playerSoldier.GetComponent<Entity>().direction = "right";
                    playerSoldier.GetComponent<Entity>().spawnedAtRow = currentSelectedSummonPoint;

                    if (playerSoldier.transform.Find("SoundManager")){
                       playerSoldier.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSummonSound();
                    }

                    // summonladıktan sonra hepsini resetle
                    ResetPlayerSoldierContainers();
                }
            }

            if (enemyDeathCounterUlti >= 20){
                pressQText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Q) && !SettingsManager.Instance.battlePaused)
                {
                    Transform parentTransform = PlayerSoldierContainers.transform;

                    if (parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().canSummon){
                        Transform transformSummonPoint = PlayerSummonPoints.transform;
                        
                        GameObject playerSoldier = null;

                        for (int i=0;i<8;i++){
                            Transform summonPoint = transformSummonPoint.GetChild(i);

                            float summonPointHeight = summonPoint.GetComponent<Renderer>().bounds.size.y;

                            float randomXOffset = Random.Range(0f,0.2f);

                            Vector3 spawnPosition = summonPoint.position - new Vector3(0.8f + randomXOffset, summonPointHeight / 3f, 0);
                        
                            playerSoldier = Instantiate(
                                parentTransform.GetChild(currentSelectedSoldierContainer).GetComponent<SoldierContainerManager>().SoldierContained,
                                spawnPosition,
                                Quaternion.identity);

                            playerSoldier.tag = "Player";
                            playerSoldier.GetComponent<Entity>().direction = "right";
                            playerSoldier.GetComponent<Entity>().spawnedAtRow = i;
                        }

                        if (playerSoldier.transform.Find("SoundManager")){
                            playerSoldier.transform.Find("SoundManager").GetComponent<EntitySoundManager>().playSummonSound();
                        }
                        // summonladıktan sonra hepsini resetle
                        ResetPlayerSoldierContainers();
                        enemyDeathCounterUlti = 0;
                    }
                }
            }
            else{
                pressQText.SetActive(false);
            }
        }

        if (playerWon && !battleEnded){
            GameManager.Instance.AllConqueredCityNames.Add(GameManager.Instance.CurrentEnemyName);
            battleEnded = true;
            winCanvas.SetActive(true);
            winCanvas.gameObject.transform.Find("Coin Amount").gameObject.GetComponent<TextMeshProUGUI>().text = "+" + (300 + enemyDeathCounterCoin*2);
            
            GameManager.Instance.DynamicDifficulty += 1;
            GameManager.Instance.balance += 300 + enemyDeathCounterCoin*2;
        }
        else if (playerLost && !battleEnded){
            battleEnded = true;
            loseCanvas.SetActive(true);
            loseCanvas.gameObject.transform.Find("SurrenderText").gameObject.SetActive(false);
            loseCanvas.gameObject.transform.Find("Coin Amount").gameObject.GetComponent<TextMeshProUGUI>().text = "-" + 75;

            if (GameManager.Instance.balance - 75 >= 0){
                GameManager.Instance.balance -= 75;
            }
        }

    }


    public void ResetPlayerSoldierContainers(){
        Transform parentTransformSoldierContainers = PlayerSoldierContainers.transform;

        foreach (Transform child in parentTransformSoldierContainers){
            child.gameObject.GetComponent<SoldierContainerManager>().timer = 0;
            child.gameObject.GetComponent<SoldierContainerManager>().canSummon = false;
        }
    }
}
