using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainmenu;

    public static bool settingsEnabled;
    public GameObject settingsmenu;
    public GameObject BG;
    public GameObject videop;

    void Start()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        settingsmenu.gameObject.SetActive(false);

    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        mainmenu.gameObject.SetActive(false);
        BG.gameObject.SetActive(false);
        videop.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackToMainMenu()
    {
        mainmenu.gameObject.SetActive(true);
        settingsmenu.gameObject.SetActive(false);
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