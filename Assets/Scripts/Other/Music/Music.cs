using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    public Sprite onMusic;
    public Sprite offMusic;

    public Image MusicButton;
    public bool isOn;


    // Start is called before the first frame update
    void Start()
    {
        isOn= true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
