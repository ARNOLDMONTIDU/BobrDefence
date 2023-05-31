using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI MoneyTxt, LivesTxt;
    public GameObject Pause;
    public GameObject Win;
    public GameObject Lose;
    public int GameMoney, LivesCount;
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

        LivesTxt.text = LivesCount.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToPause();
        }
    }

    public void PlayBtn()
    {
        timer = 1f;
        Pause.SetActive(false);        
        canSpawn = true;
    }

    public void ToPause()
    {
        timer = 0;
        Pause.SetActive(true);
        canSpawn = false;
    }
    public void ToMenuLose()
    {
        timer = 0;
        Lose.SetActive(true);
        canSpawn = false;
    }
    public void ToMenuWin()
    {
        timer = 0;
        Win.SetActive(true);
        canSpawn = false;
    }

    public void ToMainMenu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void ToLvl1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ToLvl2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ToLvl3()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MinusLive()
    {
        if (LivesCount > 1)
        {
            LivesCount--;
        }
        else
        {
            ToMenuLose();     
        }
    }
}
