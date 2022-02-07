using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    Rigidbody rig;
    CapsuleCollider collider;
    Animator anim;
    Camera cam;

    float originalHeight;
    public float reducedHeight;

    public float slideSpeed ;

    bool isSliding;
    void Start()
    {
        collider = GetComponent<CapsuleCollider>();
        rig = GetComponent<Rigidbody>();
        originalHeight = collider.height;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Sliding();
        else if (Input.GetKeyUp(KeyCode.LeftControl))
            GoUp();
    }

    private void Sliding()
    {
        anim.SetBool ("slide", true);
        collider.height = reducedHeight;
        rig.AddForce(Camera.main.transform.forward * slideSpeed, ForceMode.VelocityChange);
    }

    private void GoUp()
    {
        collider.height = originalHeight;
        anim.SetBool("slide", false);
    }
}



    
