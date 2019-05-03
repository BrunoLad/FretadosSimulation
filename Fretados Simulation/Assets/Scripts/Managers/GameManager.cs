using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public AudioSource mainMusic;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            mainMusic.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
