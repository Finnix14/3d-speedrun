using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Death : MonoBehaviour
{
    public GameObject playerUI;
    public Timer timer;
    public PlayerMovement player;
    public GameObject deathplane;
    public PlayerLook camsense;

    private void Start()
    {
        deathplane.SetActive(false);
    }



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("DeathPlane"))
            RunDeath();
    }

    public void RunDeath()
    {
      
        Time.timeScale = .25f;
        playerUI.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        deathplane.SetActive(true);
        timer.StopCoroutine("Stopwatch");
        camsense.sensX = 0;
        camsense.sensY = 0;
        player.moveSpeed = 0;
    }
}
