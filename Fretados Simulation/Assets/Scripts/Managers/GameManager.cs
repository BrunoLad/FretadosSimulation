using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public AudioSource mainMusic;               // Referência a música padrão do jogo que está sendo reproduzida
    public List<AudioSource> audioSources;      // Will consider to make this public or to get either by layer or mask

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            mainMusic.Stop();
        }

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
