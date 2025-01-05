using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool paused = false;
    private bool muted = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && SceneManager.GetActiveScene().buildIndex == 2){
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.M)){
            Mute();
        }

        if (Input.GetKeyDown(KeyCode.S) && SceneManager.GetActiveScene().buildIndex == 1){
            Play();
        }

        if (Input.GetKeyDown(KeyCode.R) && (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4)){
            Play();
        }
    }

    public void Story(){
        SceneManager.LoadScene("Story");
    }

    public void Play(){
        SceneManager.LoadScene("Tides Of Lunacy");
    }

    public void Pause(){
        if (paused){
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            paused = false;
        }
        else {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            paused = true;
        }
    }

    public void Mute(){
        if (muted){
            AudioListener.volume = 1;
            muted = false;
        }
        else {
            AudioListener.volume = 0;
            muted = true;
        }
    }

    public void Menu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit(){
        Application.Quit();
    }

    public void Secret(){
        SceneManager.LoadScene("Beastiary");
    }
}
