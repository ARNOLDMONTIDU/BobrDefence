using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellScript : MonoBehaviour
{
    public bool isGround, hasTower = false;

    public Color BaseColor, ÑurrColor;

    public GameObject ShopPref;


    private void OnMouseEnter()
    {
        if (!isGround && FindObjectOfType<ShopScript>().Lenght == 0)
            GetComponent<SpriteRenderer>().color = ÑurrColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = BaseColor;
    }

    private void OnMouseDown()
    {
        if (!isGround && FindObjectOfType<ShopScript>().Lenght == 0)
            if (!hasTower)
            {
                GameObject shopObject = Instantiate(ShopPref);
                shopObject.tranform.SetParent(GameObject.Find("Canvas").transform, false);

            }
    }
}
