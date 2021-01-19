using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject text;



    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }
    public void HidePauseMenuAndPlay()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        pauseMenu.SetActive(false);
        text.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
}
