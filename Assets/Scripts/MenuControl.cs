using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

   public GameObject settingsMenu;
   public GameObject mainButtons;
   



    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        mainButtons.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
        mainButtons.SetActive(true);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

   

}
