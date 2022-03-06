using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevel : MonoBehaviour
{
    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }
}
