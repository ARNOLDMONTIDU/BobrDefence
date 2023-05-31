using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI MoneyTxt;
    public GameObject Menu;
    public int GameMoney;
    public bool canSpawn = true;

    public float timer;

    void Awake()
    {
        Instance = this;
        timer = 1f;
    }

    void Update()
    {
        Time.timeScale = timer;
        MoneyTxt.text = GameMoney.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToMenu();
        }
    }

    public void PlayBtn()
    {
        timer = 1f;
        Menu.SetActive(false);
        canSpawn = true;
    }

    public void ToMenu()
    {
        timer = 0;
        Menu.SetActive(true);
        canSpawn = false;
    }
}
