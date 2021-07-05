using UnityEngine;
using TMPro;

public class TowersButtons : MonoBehaviour
{
    public ManagerScene Manager;
    public TextMeshProUGUI SellPriceText;
    public int SellPrice;

    private void Start()
    {
        SellPriceText.SetText(SellPrice + "$"); 
    }


    public void SellTower()
    {   
        Manager.IncreaseGold(SellPrice);
        Destroy(gameObject);
    }
}
