using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{

    public AudioMixerSnapshot paused;               // snapshot para áudio enquanto o jogo estiver pausado
    public AudioMixerSnapshot unpaused;             // snapshot para áudio enquanto o jogo não estiver pausado

    GameObject[] pauseObjects;                      // Referência ao menu de pausa do jogo

    void Start()
    {
        pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
        HidePaused();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    // Controla a pausa da cena e cria a referência para controlar via botão
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            ShowPaused();
        }
        else
        {
            Time.timeScale = 1;
            HidePaused();
        }

        Lowpass();
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }

        else

        {
            unpaused.TransitionTo(.01f);
        }
    }

    //Esconde o menu de pausa
    private void HidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }

    // Mostra o menu de pausa
    private void ShowPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    // Reinicia o jogo
    public void Reload()
    {
        Pause();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    //Carrega a cena escolhida
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
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