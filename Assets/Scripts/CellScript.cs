using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    public bool isGround;

    public Color BaseColor, ÑurrColor, DestroyColor;

    public GameObject ShopPref, TowerPref, DestroyPref;

    public GameObject SelfTower;


    private void OnMouseEnter()
    {
        if (!isGround && FindObjectsOfType<ShopScript>().Length == 0
             && FindObjectsOfType<DestroyTower>().Length == 0)
            GetComponent<SpriteRenderer>().color = ÑurrColor;
        else
            GetComponent<SpriteRenderer>().color = DestroyColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = BaseColor;
    }

    private void OnMouseDown()
    {
        if (!isGround && FindObjectsOfType<ShopScript>().Length == 0
            && GameManager.Instance.canSpawn
            && FindObjectsOfType<DestroyTower>().Length == 0)
        {
            if (!SelfTower)
            {
                GameObject shopObj = Instantiate(ShopPref);
                shopObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                shopObj.GetComponent<ShopScript>().selfCell = this;
            }
            else  
            {
                GameObject towerDestr = Instantiate(DestroyPref);
                towerDestr.transform.SetParent(GameObject.Find("Canvas").transform, false);
                towerDestr.GetComponent<DestroyTower>().SelfCell = this;
            }

        }
    }

    public void BuildTower(Tower tower)
    {
        GameObject tempTower = Instantiate(TowerPref);
        tempTower.transform.SetParent(transform, false);
        tempTower.transform.position = transform.position;
        tempTower.GetComponent<TowerScript>().selfType = (TowerType)tower.type;
        SelfTower = tempTower;
        FindObjectOfType<ShopScript>().CloseShop();
    }

    public void DestroyTower()
    {
        GameManager.Instance.GameMoney += SelfTower.GetComponent<TowerScript>().selfTower.Price / 2;
        Destroy(SelfTower);
    }

}
