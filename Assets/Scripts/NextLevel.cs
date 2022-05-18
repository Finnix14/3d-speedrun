using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
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
    public void CutScene()
    {
        SceneManager.LoadScene("Congratulations");
    }
}
