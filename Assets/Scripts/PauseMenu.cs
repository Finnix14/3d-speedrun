using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject canvasdisable;

    public GameObject mainmenu;
    public static bool settingsEnabled;

    public static bool isPaused;

    void Start()
    {
        pauseMenu.SetActive(false);
        
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)&& !settingsEnabled)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
            
    }

    public void PauseGame()
    {
        if(Time.timeScale == 1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
        

    }

    public void ResumeGame()
    {
        if(Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

    public void QuitGame()
    {
        Application.Quit();
    }
  

 


    public void Settings()
    {
        canvasdisable.SetActive(false);

        settingsEnabled = false;
    }

    public void Back()
    {
        canvasdisable.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
