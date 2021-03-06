using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{


    [Header("References")]
    [SerializeField] WallRun wallRun;

    [SerializeField] public float sensX = 100f;
    [SerializeField] public float sensY = 100f;

    [SerializeField] Transform cam = null;
    [SerializeField] public Transform orientation = null;

    [SerializeField] Camera fpscam;
    public PlayerLook look;

    float mouseX;
    float mouseY;

    float multiplier = 0.01f;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        fpscam = Camera.main;
        transform.rotation = Quaternion.Euler(mouseX, mouseY, transform.rotation.eulerAngles.z);

    }

    private void Update()
    {
        if (!PauseMenu.isPaused)
        {


            mouseX = Input.GetAxisRaw("Mouse X");
            mouseY = Input.GetAxisRaw("Mouse Y");

            yRotation += mouseX * sensX * multiplier;
            xRotation -= mouseY * sensY * multiplier;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);
            orientation.transform.rotation = Quaternion.Euler(0, yRotation, 0);
        }

    }


}