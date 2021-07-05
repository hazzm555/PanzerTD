using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public GameObject[] UpgradePanels;

    public Text GoldAmmountTXT;



    private void Start()
    {
        FillTowersDataInShop();
    }

    public void FillTowersDataInShop()
    {
        FillSmallGreenCannonDataInShop();
        FillSmallRedCannonDataInShop();
        FillSmallRocketLancherDataInShop();
        FillHeavyGreenCannonDataInShop();
        FillHeavyRedCannonDataInShop();
        FillHeavyRocketLancherDataInShop();
    }

    public void FillSmallGreenCannonDataInShop()
    {
        if (SavedData.SmallGreenCannonLVL < SavedData.SmallGreenCannonStats.GetLength(1))
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "SmallGreenCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.SmallGreenCannonStats[0, SavedData.SmallGreenCannonLVL - 1] + "  ==>  " + SavedData.SmallGreenCannonStats[0, SavedData.SmallGreenCannonLVL];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.SmallGreenCannonStats[1, SavedData.SmallGreenCannonLVL - 1] + "  ==>  " + SavedData.SmallGreenCannonStats[1, SavedData.SmallGreenCannonLVL];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.SmallGreenCannonStats[2, SavedData.SmallGreenCannonLVL - 1] + "  ==>  " + SavedData.SmallGreenCannonStats[2, SavedData.SmallGreenCannonLVL];
                    // Upgrade Price
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = SavedData.SmallGreenCannonStats[3, SavedData.SmallGreenCannonLVL - 1] + "$";
                }
            }
        }
        else
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "SmallGreenCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.SmallGreenCannonStats[0, SavedData.SmallGreenCannonLVL - 1] + "  ==>  " + SavedData.SmallGreenCannonStats[0, SavedData.SmallGreenCannonLVL - 1];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.SmallGreenCannonStats[1, SavedData.SmallGreenCannonLVL - 1] + "  ==>  " + SavedData.SmallGreenCannonStats[1, SavedData.SmallGreenCannonLVL - 1];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.SmallGreenCannonStats[2, SavedData.SmallGreenCannonLVL - 1] + "  ==>  " + SavedData.SmallGreenCannonStats[2, SavedData.SmallGreenCannonLVL - 1];
                    // Updgrade price
                    x.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "No More Upgrades";
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "0$";
                    x.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

    public void BTNSmallGreenCannonUpgradeClicked(Text PriceTXT)
    {   
        if(SavedData.SmallGreenCannonLVL < SavedData.SmallGreenCannonStats.GetLength(1))
        {
            string Price = PriceTXT.text.Substring(0, PriceTXT.text.Length - 1);

            if (int.Parse(GoldAmmountTXT.text) >= int.Parse(Price))
            {
                SavedData.SmallGreenCannonLVL++;
                SavedData.SaveTowersLVL();

                FillSmallGreenCannonDataInShop();
                
                GoldAmmountTXT.text = (int.Parse(GoldAmmountTXT.text) - int.Parse(Price)).ToString();
                SavedData.SaveGold();
            }

        }
        
        
    }

    public void FillSmallRedCannonDataInShop()
    {
        if (SavedData.SmallRedCannonLVL < SavedData.SmallRedCannonStats.GetLength(1))
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "SmallRedCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.SmallRedCannonStats[0, SavedData.SmallRedCannonLVL - 1] + "  ==>  " + SavedData.SmallRedCannonStats[0, SavedData.SmallRedCannonLVL];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.SmallRedCannonStats[1, SavedData.SmallRedCannonLVL - 1] + "  ==>  " + SavedData.SmallRedCannonStats[1, SavedData.SmallRedCannonLVL];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.SmallRedCannonStats[2, SavedData.SmallRedCannonLVL - 1] + "  ==>  " + SavedData.SmallRedCannonStats[2, SavedData.SmallRedCannonLVL];
                    // Upgrade Price
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = SavedData.SmallRedCannonStats[3, SavedData.SmallRedCannonLVL - 1] + "$";
                }
            }
        }
        else
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "SmallRedCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.SmallRedCannonStats[0, SavedData.SmallRedCannonLVL - 1] + "  ==>  " + SavedData.SmallRedCannonStats[0, SavedData.SmallRedCannonLVL - 1];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.SmallRedCannonStats[1, SavedData.SmallRedCannonLVL - 1] + "  ==>  " + SavedData.SmallRedCannonStats[1, SavedData.SmallRedCannonLVL - 1];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.SmallRedCannonStats[2, SavedData.SmallRedCannonLVL - 1] + "  ==>  " + SavedData.SmallRedCannonStats[2, SavedData.SmallRedCannonLVL - 1];
                    // Updgrade price
                    x.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "No More Upgrades";
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "0$";
                    x.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

    public void BTNSmallRedCannonUpgradeClicked(Text PriceTXT)
    {
        if (SavedData.SmallRedCannonLVL < SavedData.SmallRedCannonStats.GetLength(1))
        {
            string Price = PriceTXT.text.Substring(0, PriceTXT.text.Length - 1);

            if (int.Parse(GoldAmmountTXT.text) >= int.Parse(Price))
            {
                SavedData.SmallRedCannonLVL++;
                SavedData.SaveTowersLVL();

                FillSmallRedCannonDataInShop();

                GoldAmmountTXT.text = (int.Parse(GoldAmmountTXT.text) - int.Parse(Price)).ToString();
                SavedData.SaveGold();
            }

        }


    }

    public void FillSmallRocketLancherDataInShop()
    {
        if (SavedData.SmallRocketLancherLVL < SavedData.SmallRocketLancherStats.GetLength(1))
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "SmallRocketLancher")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.SmallRocketLancherStats[0, SavedData.SmallRocketLancherLVL - 1] + "  ==>  " + SavedData.SmallRocketLancherStats[0, SavedData.SmallRocketLancherLVL];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.SmallRocketLancherStats[1, SavedData.SmallRocketLancherLVL - 1] + "  ==>  " + SavedData.SmallRocketLancherStats[1, SavedData.SmallRocketLancherLVL];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.SmallRocketLancherStats[2, SavedData.SmallRocketLancherLVL - 1] + "  ==>  " + SavedData.SmallRocketLancherStats[2, SavedData.SmallRocketLancherLVL];
                    // Upgrade Price
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = SavedData.SmallRocketLancherStats[3, SavedData.SmallRocketLancherLVL - 1] + "$";
                }
            }
        }
        else
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "SmallRocketLancher")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.SmallRocketLancherStats[0, SavedData.SmallRocketLancherLVL - 1] + "  ==>  " + SavedData.SmallRocketLancherStats[0, SavedData.SmallRocketLancherLVL - 1];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.SmallRocketLancherStats[1, SavedData.SmallRocketLancherLVL - 1] + "  ==>  " + SavedData.SmallRocketLancherStats[1, SavedData.SmallRocketLancherLVL - 1];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.SmallRocketLancherStats[2, SavedData.SmallRocketLancherLVL - 1] + "  ==>  " + SavedData.SmallRocketLancherStats[2, SavedData.SmallRocketLancherLVL - 1];
                    // Updgrade price
                    x.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "No More Upgrades";
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "0$";
                    x.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);

                }
            }
        }
    }

    public void BTNSmallRocketLancherUpgradeClicked(Text PriceTXT)
    {
        if (SavedData.SmallRocketLancherLVL < SavedData.SmallRocketLancherStats.GetLength(1))
        {
            string Price = PriceTXT.text.Substring(0, PriceTXT.text.Length - 1);

            if (int.Parse(GoldAmmountTXT.text) >= int.Parse(Price))
            {
                SavedData.SmallRocketLancherLVL++;
                SavedData.SaveTowersLVL();

                FillSmallRocketLancherDataInShop();

                GoldAmmountTXT.text = (int.Parse(GoldAmmountTXT.text) - int.Parse(Price)).ToString();
                SavedData.SaveGold();
            }

        }


    }

    public void FillHeavyGreenCannonDataInShop()
    {
        if (SavedData.HeavyGreenCannonLVL < SavedData.HeavyGreenCannonStats.GetLength(1))
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "HeavyGreenCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.HeavyGreenCannonStats[0, SavedData.HeavyGreenCannonLVL - 1] + "  ==>  " + SavedData.HeavyGreenCannonStats[0, SavedData.HeavyGreenCannonLVL];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.HeavyGreenCannonStats[1, SavedData.HeavyGreenCannonLVL - 1] + "  ==>  " + SavedData.HeavyGreenCannonStats[1, SavedData.HeavyGreenCannonLVL];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.HeavyGreenCannonStats[2, SavedData.HeavyGreenCannonLVL - 1] + "  ==>  " + SavedData.HeavyGreenCannonStats[2, SavedData.HeavyGreenCannonLVL];
                    // Upgrade Price
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = SavedData.HeavyGreenCannonStats[3, SavedData.HeavyGreenCannonLVL - 1] + "$";
                }
            }
        }
        else
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "HeavyGreenCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.HeavyGreenCannonStats[0, SavedData.HeavyGreenCannonLVL - 1] + "  ==>  " + SavedData.HeavyGreenCannonStats[0, SavedData.HeavyGreenCannonLVL - 1];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.HeavyGreenCannonStats[1, SavedData.HeavyGreenCannonLVL - 1] + "  ==>  " + SavedData.HeavyGreenCannonStats[1, SavedData.HeavyGreenCannonLVL - 1];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.HeavyGreenCannonStats[2, SavedData.HeavyGreenCannonLVL - 1] + "  ==>  " + SavedData.HeavyGreenCannonStats[2, SavedData.HeavyGreenCannonLVL - 1];
                    // Updgrade price
                    x.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "No More Upgrades";
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "0$";
                    x.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);

                }
            }
        }
    }

    public void BTNHeavyGreenCannonUpgradeClicked(Text PriceTXT)
    {
        if (SavedData.HeavyGreenCannonLVL < SavedData.HeavyGreenCannonStats.GetLength(1))
        {
            string Price = PriceTXT.text.Substring(0, PriceTXT.text.Length - 1);

            if (int.Parse(GoldAmmountTXT.text) >= int.Parse(Price))
            {
                SavedData.HeavyGreenCannonLVL++;
                SavedData.SaveTowersLVL();

                FillHeavyGreenCannonDataInShop();

                GoldAmmountTXT.text = (int.Parse(GoldAmmountTXT.text) - int.Parse(Price)).ToString();
                SavedData.SaveGold();
            }

        }


    }

    public void FillHeavyRedCannonDataInShop()
    {
        if (SavedData.HeavyRedCannonLVL < SavedData.HeavyRedCannonStats.GetLength(1))
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "HeavyRedCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRedCannonStats[0, SavedData.HeavyRedCannonLVL - 1] + "  ==>  " + SavedData.HeavyRedCannonStats[0, SavedData.HeavyRedCannonLVL];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRedCannonStats[1, SavedData.HeavyRedCannonLVL - 1] + "  ==>  " + SavedData.HeavyRedCannonStats[1, SavedData.HeavyRedCannonLVL];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRedCannonStats[2, SavedData.HeavyRedCannonLVL - 1] + "  ==>  " + SavedData.HeavyRedCannonStats[2, SavedData.HeavyRedCannonLVL];
                    // Upgrade Price
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = SavedData.HeavyRedCannonStats[3, SavedData.HeavyRedCannonLVL - 1] + "$";
                }
            }
        }
        else
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "HeavyRedCannon")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRedCannonStats[0, SavedData.HeavyRedCannonLVL - 1] + "  ==>  " + SavedData.HeavyRedCannonStats[0, SavedData.HeavyRedCannonLVL - 1];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRedCannonStats[1, SavedData.HeavyRedCannonLVL - 1] + "  ==>  " + SavedData.HeavyRedCannonStats[1, SavedData.HeavyRedCannonLVL - 1];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRedCannonStats[2, SavedData.HeavyRedCannonLVL - 1] + "  ==>  " + SavedData.HeavyRedCannonStats[2, SavedData.HeavyRedCannonLVL - 1];
                    // Updgrade price
                    x.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "No More Upgrades";
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "0$";
                    x.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

    public void BTNHeavyRedCannonUpgradeClicked(Text PriceTXT)
    {
        if (SavedData.HeavyRedCannonLVL < SavedData.HeavyRedCannonStats.GetLength(1))
        {
            string Price = PriceTXT.text.Substring(0, PriceTXT.text.Length - 1);

            if (int.Parse(GoldAmmountTXT.text) >= int.Parse(Price))
            {
                SavedData.HeavyRedCannonLVL++;
                SavedData.SaveTowersLVL();

                FillHeavyRedCannonDataInShop();

                GoldAmmountTXT.text = (int.Parse(GoldAmmountTXT.text) - int.Parse(Price)).ToString();
                SavedData.SaveGold();
            }

        }


    }

    public void FillHeavyRocketLancherDataInShop()
    {
        if (SavedData.HeavyRocketLancherLVL < SavedData.HeavyRocketLancherStats.GetLength(1))
        {

            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "HeavyRocketLancher")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRocketLancherStats[0, SavedData.HeavyRocketLancherLVL - 1] + "  ==>  " + SavedData.HeavyRocketLancherStats[0, SavedData.HeavyRocketLancherLVL];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRocketLancherStats[1, SavedData.HeavyRocketLancherLVL - 1] + "  ==>  " + SavedData.HeavyRocketLancherStats[1, SavedData.HeavyRocketLancherLVL];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRocketLancherStats[2, SavedData.HeavyRocketLancherLVL - 1] + "  ==>  " + SavedData.HeavyRocketLancherStats[2, SavedData.HeavyRocketLancherLVL];
                    // Upgrade Price
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = SavedData.HeavyRocketLancherStats[3, SavedData.HeavyRocketLancherLVL - 1] + "$";
                }
            }
        }
        else
        {
            foreach (GameObject x in UpgradePanels)
            {
                if (x.name == "HeavyRocketLancher")
                {
                    //Attack text
                    x.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRocketLancherStats[0, SavedData.HeavyRocketLancherLVL - 1] + "  ==>  " + SavedData.HeavyRocketLancherStats[0, SavedData.HeavyRocketLancherLVL - 1];
                    //Attack Speed
                    x.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRocketLancherStats[1, SavedData.HeavyRocketLancherLVL - 1] + "  ==>  " + SavedData.HeavyRocketLancherStats[1, SavedData.HeavyRocketLancherLVL - 1];
                    //Cost
                    x.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = SavedData.HeavyRocketLancherStats[2, SavedData.HeavyRocketLancherLVL - 1] + "  ==>  " + SavedData.HeavyRocketLancherStats[2, SavedData.HeavyRocketLancherLVL - 1];
                    // Updgrade price
                    x.transform.GetChild(5).GetChild(0).GetComponent<Text>().text = "No More Upgrades";
                    x.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "0$";
                    x.transform.GetChild(5).GetChild(1).gameObject.SetActive(false);
                }
            }
        }
    }

    public void BTNHeavyRocketLancherUpgradeClicked(Text PriceTXT)
    {
        if (SavedData.HeavyRocketLancherLVL < SavedData.HeavyRocketLancherStats.GetLength(1))
        {
            string Price = PriceTXT.text.Substring(0, PriceTXT.text.Length - 1);

            if (int.Parse(GoldAmmountTXT.text) >= int.Parse(Price))
            {
                SavedData.HeavyRocketLancherLVL++;
                SavedData.SaveTowersLVL();

                FillHeavyRocketLancherDataInShop();

                GoldAmmountTXT.text = (int.Parse(GoldAmmountTXT.text) - int.Parse(Price)).ToString();
                SavedData.SaveGold();
            }

        }


    }

}
