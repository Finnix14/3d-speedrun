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
    //[SerializeField] public Slider staminaStats;
    public float staminaValue;
    public float slideSpeed;
    public Text staminaUI;


    int staminaCount;
    bool isSliding;


    public float stamina;
    float maxstamina;

    public Slider staminaBar;
    public float dValue;


    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = col.height;
        anim = GetComponent<Animator>();
        player = GetComponent <PlayerMovement>();

        currentStamina = totalStamina;
        maxstamina = stamina;
        staminaBar.maxValue = maxstamina;
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



        staminaUI.text = string.Format("{0}", currentStamina);
    }

    public void Sliding()
    {
        if(currentStamina >= 5)
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

    public void DecreaseEnergy()
    {
        if (stamina != 0)
            stamina -= dValue * Time.deltaTime;
    }
    public void IncreaseEnergy()
    {
        stamina += dValue * Time.deltaTime;
    }

}



    
