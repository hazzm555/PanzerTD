using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EnterySceneManager : MonoBehaviour
{
    public GameObject[] DisableOnPlay;
    public GameObject[] EnableOnPlay;
    public Button[] StagesButtons;
    public GameObject Shop;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < StagesButtons.Length; i++)
        {
            //if (PlayerPrefs.HasKey("StageButton" + i))
            //{
                if (PlayerPrefs.GetInt("StageButton" + i) == 0)
                {
                    StagesButtons[i].interactable = false;
                }
                else if(PlayerPrefs.GetInt("StageButton" + i) == 1)
                {
                    StagesButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                    StagesButtons[i].interactable = true;
                }
            //}
            /*else
            {
                if (i == 0)
                {
                    PlayerPrefs.SetInt("StageButton0", 1);
                    StagesButtons[i].transform.GetChild(0).gameObject.SetActive(false);
                    StagesButtons[i].interactable = true;
                }
                else
                {
                    PlayerPrefs.SetInt("StageButton" + i, 0);
                    StagesButtons[i].interactable = false;
                }
                
            }*/

        }
        
        PlayerPrefs.Save();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayBTNClicked()
    {
        foreach (GameObject x in DisableOnPlay)
        {
            x.SetActive(false);
        }

        foreach (GameObject x in EnableOnPlay)
        {
            x.SetActive(true);
        }

    }

    public void CloseStagePanelBTNClicked()
    {
        foreach (GameObject x in DisableOnPlay)
        {
            x.SetActive(true);
        }

        foreach (GameObject x in EnableOnPlay)
        {
            x.SetActive(false);
        }
    }

    public void Stage1ButtonClicked()
    {
        SceneManager.LoadScene("NKTD2");
    }

    public void Stage2ButtonClicked()
    {
        SceneManager.LoadScene("SecondLevel");
    }

    public void ExitBTNClicked()
    {
        Application.Quit();
    }

    public void ShopBTNClicked()
    {
        Shop.SetActive(true);
        foreach (GameObject x in DisableOnPlay)
        {
            x.SetActive(false);
        }
    }

    public void CloseShopBTNClicked()
    {
        Shop.SetActive(false);
        foreach (GameObject x in DisableOnPlay)
        {
            x.SetActive(true);
        }
    }

}
