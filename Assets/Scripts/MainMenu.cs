using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject canvasdisable;
    public GameObject canvasenable;
    public static bool settingsEnabled;

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
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