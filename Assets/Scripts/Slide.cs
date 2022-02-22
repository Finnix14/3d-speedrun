using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    Rigidbody rig;
    CapsuleCollider col;
    Animator anim;
    Camera cam;
    public PlayerMovement player;
    float originalHeight;
    public float reducedHeight;

    public float slideSpeed ;

    bool isSliding;

    
    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = col.height;
        anim = GetComponent<Animator>();
        player = GetComponent <PlayerMovement>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)&& player.isGrounded)
            Sliding();
        else if (Input.GetKeyUp(KeyCode.LeftControl)&& isSliding)
            GoUp();
    }

    private void Sliding()
    {
        
        
        col.height = reducedHeight;
        rig.AddForce(Camera.main.transform.forward * slideSpeed, ForceMode.VelocityChange);
        isSliding = true;
    }

    private void GoUp()
    {
        col.height = originalHeight;
        
        isSliding = false;
    }
}



    
