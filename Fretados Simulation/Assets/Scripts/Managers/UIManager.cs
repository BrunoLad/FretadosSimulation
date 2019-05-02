using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public AudioSource music; // Referência a música que está sendo reproduzida
    public Sprite offSprite; // Referência para o sprite de música quando não estiver tocando
    public Sprite onSprite; // Referência para o sprite de música quando estiver tocando

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Carrega a cena escolhida
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void TurnMusicOnOff()
    {
        Image buttonImg = GameObject.Find("MusicButton").GetComponent<Image>();
        if (music.isPlaying)
        {
            music.Stop();
            buttonImg.sprite = offSprite;
        } else
        {
            music.Play();
            buttonImg.sprite = onSprite;
        }
    }

    //Encerra o jogo
    public void Quit()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
		Application.Quit();
        #endif
    }
}
