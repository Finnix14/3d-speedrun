using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public GameObject mainmenu;
    public GameObject settingsmenu;
    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial Level");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void Quitting()
    {
        Application.Quit();
    }

    public void Settings()
    {
        mainmenu.gameObject.SetActive(false);
        settingsmenu.gameObject.SetActive(true);
    }
   
}