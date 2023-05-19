using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;
    public TextMeshProUGUI MoneyTxt;
    public int GameMoney;


    void Awake()
    {
        Instance = this;


    }

    void Update()
    {
        MoneyTxt.text = GameMoney.ToString(); 
    }
}
