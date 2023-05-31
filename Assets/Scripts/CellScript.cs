using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    public bool isGround, hasTower = false;

    public Color BaseColor, ÑurrColor, DestroyColor;

    public GameObject ShopPref, TowerPref;




    private void OnMouseEnter()
    {
        if (!isGround && FindObjectsOfType<ShopScript>().Length == 0)
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
            && GameManager.Instance.canSpawn)
        {
            if (!hasTower)
            {
                GameObject shopObj = Instantiate(ShopPref);
                shopObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                shopObj.GetComponent<ShopScript>().selfCell = this;
            }
        }
    }

    public void BuildTower(Tower tower)
    {
        GameObject tempTower = Instantiate(TowerPref);
        tempTower.transform.SetParent(transform, false);
        tempTower.transform.position = transform.position;
        tempTower.GetComponent<TowerScript>().selfType = (TowerType)tower.type;
        hasTower = true;
        FindObjectOfType<ShopScript>().CloseShop();
    }

}
