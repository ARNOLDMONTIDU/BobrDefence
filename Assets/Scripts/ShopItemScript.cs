using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemScript : MonoBehaviour
{
    Tower selfTower;
    public Image TowerLogo;
    public TextMeshProUGUI TowerName, TowerPrice;

    public void SetStartData(Tower tower)
    {
        selfTower = tower;
        TowerLogo.sprite = tower.Spr;
        TowerName.text = tower.Name;
        TowerPrice.text = tower.Price.ToString();

    }
    

}
