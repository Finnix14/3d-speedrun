using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slide : MonoBehaviour
{
    Rigidbody rig;
    CapsuleCollider col;
    Animator anim;
    Camera cam;
    public PlayerMovement player;
    float originalHeight;
    public float reducedHeight;
    
    [Header("Stamina")]
    [SerializeField] float totalStamina = 10;
    [SerializeField] float currentStamina;
    [SerializeField] Slider staminaBar;

    public float staminaValue;
    public float slideSpeed;



    int staminaCount;
    bool isSliding;


    public float stamina;
    float maxstamina;

    


    void Start()
    {
        Time.timeScale = 1;
        currentStamina = totalStamina;
        staminaBar.maxValue = 10;
        staminaBar.minValue = 0;
       
        col = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = col.height;
        anim = GetComponent<Animator>();
        player = GetComponent <PlayerMovement>();

     
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && player.isGrounded)
            Sliding();


        else if (Input.GetKeyUp(KeyCode.C) && isSliding)
            GoUp();

        currentStamina += Time.deltaTime;

        if(currentStamina >= 10)
        {
            currentStamina = 10;
        }
        if(currentStamina <= 0)
        {
            currentStamina = 0;
        }

        staminaBar.value = currentStamina;

        
    }

    public void Sliding()
    {
        if(currentStamina >= 0)
        {
            col.height = reducedHeight;
            currentStamina -= 3;
            
            rig.AddForce(Camera.main.transform.forward * slideSpeed, ForceMode.VelocityChange);
            
            isSliding = true;
        }
            
    }

    public void GoUp()
    {
        col.height = originalHeight;
        isSliding = false;
    }


}



    
