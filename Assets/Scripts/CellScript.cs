using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellScript : MonoBehaviour
{
    public bool isGround, hasTower = false;

    public Color BaseColor, ÑurrColor;


    private void OnMouseEnter()
    {
        if (!isGround)
            GetComponent<SpriteRenderer>().color = ÑurrColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = BaseColor;
    }

    private void OnMouseDown()
    {
        
    }
}
