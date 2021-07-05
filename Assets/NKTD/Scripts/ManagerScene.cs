using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerScene : MonoBehaviour
{

    public GameObject[] EnemyMovementPoints; // 0 = Spawn Point
    public GameObject[] TanksPrefabs;
    public GameObject[] Towers;

    public Touch TowerTouch;
    public int TouchId;
    public bool DraggingTower = false;
    public static GameObject SpriteTower;
    public Vector3 MoveTowerTo;
    public static List<GameObject> EnemiesList = new List<GameObject>();

    public int Lives = 10;
    public int WaveSpawnedEnemies = 0;
    public int EnemiesKilledThisWave = 0;
    public int WaveEnemiesNum = 0;
    public TextMeshProUGUI GoldText, WaveText, LivesText;

    public int Wave = 1;
    public float TimeBetweenEnemySpawn = 2.5f;
    public float TimeBetweenWaves = 15f;

    public int Cost = 0;

    public int GoldWinReward = 200;
    public TextMeshProUGUI GoldWinRewardText;

    public GameObject[] WinLoseDisableComponents;
    public GameObject[] WinEnableComponents;
    public GameObject[] LoseEnableComponents;
    public GameObject MenuCanvas;
    public GameObject MenuPanel, MenuText;
    public GameObject SurrendConfermingPanel;

    public GameObject SelectedTower;

    public int Stage = 1;

    public int TimeScaller = 1;
    public bool JustSelected = false;

    public Transform GroundCanvas;
    public float RangeOfDeselect = 3f;

    // Start is called before the first frame update
    void Start()
    {
        GoldWinRewardText.text = "Gold : " + GoldWinReward;
        //Instantiate and sets a ref to this script
        LivesText.text = Lives + " / 10";
        SpawnWave();
        StartCoroutine("SpawnWave");
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = TimeScaller;
        /*if (EnemiesKilledThisWave == WaveEnemiesNum)
        {
            Debug.Log("Update Call SpawnWave");
            StartCoroutine("SpawnWave");
        }*/
        foreach(Touch x in Input.touches) {
            if (x.phase == TouchPhase.Began && SelectedTower != null)
            {
                Vector3 t = x.position;
                t.z = 10;
                Debug.Log(Vector2.Distance(Camera.main.ScreenToWorldPoint(t), SelectedTower.transform.position));
                if (!JustSelected && Vector2.Distance(Camera.main.ScreenToWorldPoint(t), SelectedTower.transform.position) > RangeOfDeselect)
                {
                    Debug.Log("Deselect" + SelectedTower.name);
                    SelectedTower.transform.GetChild(2).gameObject.SetActive(false);
                    SelectedTower = null;
                }
                else
                {
                    Debug.Log("To False");
                    //Invoke("SelectingDelay", 0.3f);
                    JustSelected = false;
                }
            }
        }

        if (DraggingTower)
        {
            foreach (Touch touch in Input.touches)
            {
                if (TouchId == touch.fingerId)
                {
                    TowerTouch = touch;
                }
            }
            if (TowerTouch.phase == TouchPhase.Moved)
            {
                MoveTowerTo = TowerTouch.position;
                MoveTowerTo.z = 10;
                SpriteTower.transform.position = Camera.main.ScreenToWorldPoint(MoveTowerTo);

            }
            else if (TowerTouch.phase == TouchPhase.Ended || TowerTouch.phase == TouchPhase.Canceled)
            {
                if (SpriteTower)
                {
                    SpriteTower.transform.GetChild(2).GetChild(0).gameObject.SetActive(true);
                }
                DraggingTower = false;
                PlaceTower();
            }
            
        }
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void PlaceTower()
    {

        Towers TScript = SpriteTower.GetComponent<Towers>();
        TScript.enabled = true;
        TScript.Manager = this;
        TowersButtons TBScript = SpriteTower.GetComponent<TowersButtons>();
        TBScript.Manager = this;
        SpriteTower.transform.GetChild(2).gameObject.SetActive(false);
        TowersPlacer tp = SpriteTower.GetComponent<TowersPlacer>();

        if (tp.collided == false)
        {
            GoldText.text = (int.Parse(GoldText.text) - Cost) + "";
            tp.Placed = true;
            tp.enabled = false;
        }
        else
        {

            Destroy(SpriteTower);
        }

    }


    // Sets the movement point to the tanks 
    public void TankMovementPointsGetter(TankMovement x)
    {
        x.MovePoints = new GameObject[EnemyMovementPoints.Length - 1];

        for (int i = 1; i < EnemyMovementPoints.Length; i++)
        {
            x.MovePoints[i - 1] = EnemyMovementPoints[i];
        }

    }



    public Vector3 SpawnAt;

    public void SpawnTowersButton()
    {
        GameObject Clicked = EventSystem.current.currentSelectedGameObject;

        foreach (GameObject tower in Towers)
        {
            if (Clicked.name == tower.name)
            {

                string TowerCost = Clicked.transform.GetChild(2).GetComponent<Text>().text;
                foreach (Touch touch in Input.touches)
                {

                    if (touch.phase == TouchPhase.Began && !DraggingTower && int.Parse(GoldText.text) >= int.Parse(TowerCost.Substring(0, TowerCost.Length - 1)))
                    {
                        Cost = int.Parse(TowerCost.Substring(0, TowerCost.Length - 1));
                        DraggingTower = true;
                        TowerTouch = touch;
                        TouchId = TowerTouch.fingerId;
                        SpawnAt = touch.position;
                        SpawnAt.z = 10;
                        SpawnAt = Camera.main.ScreenToWorldPoint(SpawnAt);
                        SpriteTower = Instantiate(tower, SpawnAt, Quaternion.identity, GroundCanvas);
                        SpriteTower.GetComponent<Towers>().enabled = false;
                        SpriteTower.transform.GetChild(2).gameObject.SetActive(true);
                        break;
                    }
                }
                break;
            }
        }

    }

    public IEnumerator SpawnWave()
    {
        // check the scene name to know which script wave we should use
        if (SceneManager.GetActiveScene().name == "NKTD2")
        {
            WaveEnemiesNum = Level1Waves.Waves[Wave - 1].GetLength(0);
            while (true)
            {

                if (WaveSpawnedEnemies < WaveEnemiesNum)
                {
                    SpawnEnemy(TanksPrefabs[Level1Waves.Waves[Wave - 1][WaveSpawnedEnemies]]);
                    yield return new WaitForSeconds(TimeBetweenEnemySpawn);
                }
                else if (EnemiesKilledThisWave == WaveEnemiesNum)
                {
                    WaveSpawnedEnemies = 0;
                    EnemiesKilledThisWave = 0;
                    Wave++;
                    if (Wave <= Level1Waves.Waves.GetLength(0))
                    {
                        WaveText.SetText(Wave + "  /  " + Level1Waves.WaveNumbers);
                        yield return new WaitForSeconds(TimeBetweenWaves);
                        WaveEnemiesNum = Level1Waves.Waves[Wave - 1].GetLength(0);
                    }
                    else
                    {
                        CheckWin();
                        break;
                    }


                }
                else
                {
                    yield return new WaitForSeconds(1f);
                }


            }
        }
        else if (SceneManager.GetActiveScene().name == "SecondLevel")
        {
            WaveEnemiesNum = Level2Waves.Waves[Wave - 1].GetLength(0);

            while (true)
            {

                if (WaveSpawnedEnemies < WaveEnemiesNum)
                {
                    SpawnEnemy(TanksPrefabs[Level2Waves.Waves[Wave - 1][WaveSpawnedEnemies]]);
                    yield return new WaitForSeconds(TimeBetweenEnemySpawn);
                }
                else if (EnemiesKilledThisWave == WaveEnemiesNum)
                {
                    WaveSpawnedEnemies = 0;
                    EnemiesKilledThisWave = 0;
                    Wave++;
                    if (Wave <= Level2Waves.Waves.GetLength(0))
                    {
                        WaveText.SetText(Wave + "  /  " + Level2Waves.WaveNumbers);
                        yield return new WaitForSeconds(TimeBetweenWaves);
                        WaveEnemiesNum = Level2Waves.Waves[Wave - 1].GetLength(0);
                    }
                    else
                    {
                        CheckWin();
                        break;
                    }


                }
                else
                {
                    yield return new WaitForSeconds(1f);
                }


            }
        }

        

    }

    public void CheckWin()
    {
        if (Lives > 0)
        {
            //Win
            Win();
        }
    }

    
    public void SpawnEnemy(GameObject Enemy)
    {
        WaveSpawnedEnemies++;
        EnemiesList.Add(Instantiate(Enemy, EnemyMovementPoints[0].transform.position, Quaternion.identity, GroundCanvas));
        EnemiesList[EnemiesList.Count - 1].GetComponent<TankMovement>().Manager = this;
        EnemiesList[EnemiesList.Count - 1].GetComponent<Enemies>().Manager = this;
        EnemiesList[EnemiesList.Count - 1].name += EnemiesList.Count;
        
    }

    public void IncreaseGold(int KillGold)
    {
        GoldText.text = KillGold + int.Parse(GoldText.text) + "";
    }

    public void ReduceLives(int Ammount)
    {
        Lives -= Ammount;
        if (Lives <= 0)
        {
            LivesText.text = "0 / 10";
            Lose();
        }
        else
        {
            LivesText.text = Lives + " / 10";
        }
    }

    public void ToEnteryScene()
    {
        SceneManager.LoadScene("Entery");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Win()
    {
        foreach (GameObject x in WinLoseDisableComponents)
        {
            x.SetActive(false);
        }

        foreach (GameObject x in WinEnableComponents)
        {
            x.SetActive(true);
        }
        PlayerPrefs.SetInt("GoldAmmount", PlayerPrefs.GetInt("GoldAmmount") + GoldWinReward);
        PlayerPrefs.SetInt("StageButton" + Stage, 1);
        PlayerPrefs.Save();
    }

    public void Lose()
    {
        foreach (GameObject x in WinLoseDisableComponents)
        {
            x.SetActive(false);
        }

        foreach (GameObject x in LoseEnableComponents)
        {
            x.SetActive(true);
        }
    }

    public void MenuBTNClicked()
    {
        foreach (GameObject x in WinLoseDisableComponents)
        {
            x.SetActive(false);
        }

        TimeScaller = 0;

        MenuCanvas.SetActive(true);
        
    }

    public void ResumeBTNClicked()
    {
        foreach (GameObject x in WinLoseDisableComponents)
        {
            x.SetActive(true);
        }

        TimeScaller = 1;

        MenuCanvas.SetActive(false);
    }

    public void SurrendBTNClicked()
    {
        MenuPanel.SetActive(false);
        MenuText.SetActive(false);
        SurrendConfermingPanel.SetActive(true);

    }

    public void SurrendBTNRefused()
    {
        SurrendConfermingPanel.SetActive(false);
        MenuText.SetActive(true);
        MenuPanel.SetActive(true);
    }

    public void SurrendBTNConfermedClicked()
    {
        SurrendConfermingPanel.SetActive(false);
        Lose();
    }

    public void SetSelectedTower(GameObject Selected)
    {
        Debug.Log("Selected" + Selected.name);
        JustSelected = true;
        if (SelectedTower != null)
        {
            SelectedTower.transform.GetChild(2).gameObject.SetActive(false);

        }
        SelectedTower = Selected;
        SelectedTower.transform.GetChild(2).gameObject.SetActive(true);
        
    }

    public void SelectingDelay()
    {
        JustSelected = false;
    }

}
