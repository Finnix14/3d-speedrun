using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameObject gameUICanvas;

    
    public PlayerMovement player;

    public AudioSource slowmomusic;
    public AudioSource slowmoSFX;


    void Start()
    {
        gameUICanvas.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            
            gameUICanvas.SetActive(true);
            Time.timeScale = .7f;
           
            player.moveSpeed = 0;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            slowmomusic.pitch = Time.timeScale;
            slowmoSFX.pitch = Time.timeScale;
        }
    }

    public void Update()
    {
        slowmomusic.pitch = Time.timeScale;
        slowmoSFX.pitch = Time.timeScale;
    }
}
