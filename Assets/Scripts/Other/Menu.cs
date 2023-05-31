using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ToLvl1M()
    {
        SceneManager.LoadScene("Level1");
    }
    public void ToLvl2M()
    {
        SceneManager.LoadScene("Level2");
    }
    public void ToLvl3M()
    {
        SceneManager.LoadScene("Level1");
    }
}
