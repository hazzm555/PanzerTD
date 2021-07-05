using UnityEngine;
using UnityEngine.UI;
public class SavedData : MonoBehaviour
{

    public static Text GoldAmmountTXT;



    // Gold that the player has in entery scene
    public static int GoldAmmount = 0;

    //Stages Opened false not open ,ture opened
    public static int StageButton0 = 1;
    public static int StageButton1 = 0;

    
    public static int SmallGreenCannonLVL = 1;
    public static int SmallRedCannonLVL = 1;
    public static int SmallRocketLancherLVL = 1;
    public static int HeavyGreenCannonLVL = 1;
    public static int HeavyRedCannonLVL = 1;
    public static int HeavyRocketLancherLVL = 1;

    public enum TowersName
    {
        SmallGreenCannonLVL,
        SmallRedCannonLVL,
        SmallRocketLancherLVL,
        HeavyGreenCannonLVL,
        HeavyRedCannonLVL,
        HeavyRocketLancherLVL
    };

    public static TowersName[] TowersName1 = {TowersName.SmallGreenCannonLVL,
        TowersName.SmallRedCannonLVL,
        TowersName.SmallRocketLancherLVL,
        TowersName.HeavyGreenCannonLVL,
        TowersName.HeavyRedCannonLVL,
        TowersName.HeavyRocketLancherLVL };

    //price not working

    /// <summary>
    /// needs work in unity and fix data in arrays
    /// </summary>
    public static float[,] SmallGreenCannonStats = new float[,] { {1, 1, 2}, {2, 1.9f, 3f}, {30, 30, 30}, {500, 1000, 1500} }; //0 attack, 1 Attack speed, 2 Price, 3 Upgrade cost
    public static float[,] SmallRedCannonStats = new float[,] { { 1, 1, 1 }, { 0.95f, 0.89f, 0.85f}, { 60, 60, 60 }, { 1000, 2000, 2500 } };
    public static float[,] SmallRocketLancherStats = new float[,] { { 5, 5, 5 }, { 3.2f, 3, 2.8f }, { 75, 75, 75 }, { 1750, 2500, 5000 } };
    public static float[,] HeavyGreenCannonStats = new float[,] { { 6, 6, 7 }, { 1.75f, 1.65f, 1.55f }, { 150, 150, 150 }, { 2250, 3000, 3500 } };
    public static float[,] HeavyRedCannonStats = new float[,] { { 3, 3, 4 }, { 0.45f, 0.42f, 0.4f }, { 300, 300, 300 }, { 3000, 4000, 5000 } };
    public static float[,] HeavyRocketLancherStats = new float[,] { { 50, 60, 75 }, { 5, 5f, 4.8f }, { 500, 500, 500 }, { 5000, 7500, 15000 }};

    private void Awake()
    {
        GoldAmmountTXT = transform.GetComponent<ShopManager>().GoldAmmountTXT;

        //GOLD
        FillGold();
        //Stages
        FillStages();
        //Tower LVLS
        FillTowersLVL();

        PlayerPrefs.Save();
    }


    public static void FillGold() {
        if (PlayerPrefs.HasKey("GoldAmmount"))
        {
            Debug.Log("Found");
            GoldAmmount = PlayerPrefs.GetInt("GoldAmmount");
            GoldAmmountTXT.text = GoldAmmount.ToString();
        }
        else
        {
            PlayerPrefs.SetInt("GoldAmmount", 0);

        }
    }

    public static void FillStages()
    {
        // Stage1
        if(!PlayerPrefs.HasKey("StageButton0"))
        {
            PlayerPrefs.SetInt("StageButton0", 1);
        }

        if (!PlayerPrefs.HasKey("StageButton1"))
        {
            PlayerPrefs.SetInt("StageButton1", 0);
        }

    }

    public static void FillTowersLVL()
    {
        foreach (TowersName x in TowersName1)
        {
            if (x == TowersName.SmallGreenCannonLVL)
            {
                if (PlayerPrefs.HasKey(x.ToString()))
                {
                    SmallGreenCannonLVL = PlayerPrefs.GetInt(x.ToString());
                }
                else
                {
                    PlayerPrefs.SetInt(x.ToString(), SmallGreenCannonLVL);
                }
            }
            else if (x == TowersName.SmallRedCannonLVL)
            {
                if (PlayerPrefs.HasKey(x.ToString()))
                {
                    SmallRedCannonLVL = PlayerPrefs.GetInt(x.ToString());
                }
                else
                {
                    PlayerPrefs.SetInt(x.ToString(), SmallRedCannonLVL);
                }
            }
            else if (x == TowersName.SmallRocketLancherLVL)
            {
                if (PlayerPrefs.HasKey(x.ToString()))
                {
                    SmallRocketLancherLVL = PlayerPrefs.GetInt(x.ToString());
                }
                else
                {
                    PlayerPrefs.SetInt(x.ToString(), SmallRocketLancherLVL);
                }
            }
            else if (x == TowersName.HeavyGreenCannonLVL)
            {
                if (PlayerPrefs.HasKey(x.ToString()))
                {
                    HeavyGreenCannonLVL = PlayerPrefs.GetInt(x.ToString());
                }
                else
                {
                    PlayerPrefs.SetInt(x.ToString(), HeavyGreenCannonLVL);
                }
            }
            else if (x == TowersName.HeavyRedCannonLVL)
            {
                if (PlayerPrefs.HasKey(x.ToString()))
                {
                    HeavyRedCannonLVL = PlayerPrefs.GetInt(x.ToString());
                }
                else
                {
                    PlayerPrefs.SetInt(x.ToString(), HeavyRedCannonLVL);
                }
            }
            else if (x == TowersName.HeavyRocketLancherLVL)
            {
                if (PlayerPrefs.HasKey(x.ToString()))
                {
                    HeavyRocketLancherLVL = PlayerPrefs.GetInt(x.ToString());
                }
                else
                {
                    PlayerPrefs.SetInt(x.ToString(), HeavyRocketLancherLVL);
                }
            }
        }
    }

    public static void SaveTowersLVL()
    {
        foreach (TowersName x in TowersName1)
        {

            if (x == TowersName.SmallGreenCannonLVL)
            {
                PlayerPrefs.SetInt(x.ToString(), SmallGreenCannonLVL);
            }
            else if (x == TowersName.SmallRedCannonLVL)
            {
                PlayerPrefs.SetInt(x.ToString(), SmallRedCannonLVL);
            }
            else if (x == TowersName.SmallRocketLancherLVL)
            {
                PlayerPrefs.SetInt(x.ToString(), SmallRocketLancherLVL);
            }
            else if (x == TowersName.HeavyGreenCannonLVL)
            {
                PlayerPrefs.SetInt(x.ToString(), HeavyGreenCannonLVL);
            }
            else if (x == TowersName.HeavyRedCannonLVL)
            {
                PlayerPrefs.SetInt(x.ToString(), HeavyRedCannonLVL);
            }
            else if (x == TowersName.HeavyRocketLancherLVL)
            {
                PlayerPrefs.SetInt(x.ToString(), HeavyRocketLancherLVL);
            }
            
        }

        PlayerPrefs.Save();

    }

    public static void SaveGold()
    {
        PlayerPrefs.SetInt("GoldAmmount", int.Parse(GoldAmmountTXT.text));
        PlayerPrefs.Save();
    }

}
