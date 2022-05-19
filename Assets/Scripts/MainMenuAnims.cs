using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuAnims : MonoBehaviour
{
    public Animator anim;
    

    public void PlaySwoosh()
    {
        anim.SetTrigger("Play");
    }

    public void OptionsSwoosh()
    {
        anim.SetTrigger("Options");
    }

    public void OptionsBack()
    {
        anim.SetTrigger("OptionsBack");
    }
    public void PlayBack()
    {
        anim.SetTrigger("PlayBack");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Level 1");
    }  
    public void Level1()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void SecretRoom()
    {
        anim.SetTrigger("Secret");
    }

    public void SecretRoomBack()
    {
        anim.SetTrigger("SecretBack");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("PrototypeMainMenu");
    }
}
