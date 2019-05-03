using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsManager : UIManager
{
    public Sprite musicOffSprite;               // Referência para o sprite de música quando não estiver tocando
    public Sprite musicOnSprite;                // Referência para o sprite de música quando estiver tocando
    public Sprite soundOffSprite;               // Referência para o sprite de som ligado
    public Sprite soundOnSprite;               // Referência para o sprite de som desligado
    GameObject[] settingsObjects;               // Referência aos elementos com a tag do menu Settings

    // Start is called before the first frame update
    void Start()
    {
        settingsObjects = GameObject.FindGameObjectsWithTag("SettingsMenu");
        HideSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideSettings()
    {
        foreach (GameObject g in settingsObjects)
        {
            g.SetActive(false);
        }
    }

    public void ShowSettings()
    {
        Debug.Log("teste");
        foreach (GameObject g in settingsObjects)
        {
            g.SetActive(true);
        }
    }

    public void TurnMusicOnOff()
    {
        Image musicImg = GameObject.Find("MusicButton").GetComponent<Image>();

        if (music.isPlaying)
        {
            music.Stop();
            musicImg.sprite = musicOffSprite;
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            music.Play();
            musicImg.sprite = musicOnSprite;
            PlayerPrefs.SetInt("Music", 1);
        }
    }

    public void TurnSoundOnOff()
    {
        Image soundImg = GameObject.Find("SoundButton").GetComponent<Image>();

        // Just putting this as is as a test
        if (true)
        {
            soundImg.sprite = soundOffSprite;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            soundImg.sprite = soundOnSprite;
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
}
