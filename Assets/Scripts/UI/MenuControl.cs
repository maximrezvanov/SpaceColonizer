using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

   public GameObject settingsMenu;
   public GameObject mainButtons;

    private void Awake()
    {
        GameObject setMenu = GameObject.Find("SettingsMenuPanel");
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }



    public void ExitGame()
    {
        Application.Quit();
    }

   

}
