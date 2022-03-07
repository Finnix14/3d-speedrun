using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject canvasdisable;
    public GameObject canvasenable;
    public static bool settingsEnabled;
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quitting()
    {
        Application.Quit();
    }

    public void Settings()
    {
        canvasdisable.SetActive(false);
        canvasenable.SetActive(true);
        settingsEnabled = false;
    }
   
}