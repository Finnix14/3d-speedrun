using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
   
    CapsuleCollider col;
    Camera cam;
    public PlayerMovement player;
    public GameObject shotgun;
    public Rigidbody playerRig;

    public float launchForce;

    public bool isShotgun = false;

    // Start is called before the first frame update

  



    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        playerRig = GetComponent<Rigidbody>();
        player = GetComponent<PlayerMovement>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && shotgun == true) 
        {
            Propell();
        }
    }

    void Propell()
    {
        playerRig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
    }

}
