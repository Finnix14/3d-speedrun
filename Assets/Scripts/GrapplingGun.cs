using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GrapplingGun : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;

    public Transform gunTip, camera, player;

    private float maxDistance = 20f;
    private SpringJoint joint;
    public AudioSource shoot;
    public AudioSource gunshoot;


    public PlayerMovement playermove;




    public ParticleSystem muzzleflash;

    public bool isGrapple;

    public Rigidbody playerRig;
    public Animator anim;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        anim = GetComponent<Animator>();
        shoot = GetComponent<AudioSource>();
        isGrapple = false;
       
    }


    void Update()
    {


            if (Time.timeScale == 1)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    StartGrapple();

                }
                else if (Input.GetMouseButtonUp(0))
                {
                    StopGrapple();

                }

            } 
        
         
    }


    void StartGrapple()
    {
        RaycastHit hit;
        shootGrapple();
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            isGrapple = true;
            shoot.Play();
            muzzleflash.Play();
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);


            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;


            joint.spring = 8f;
            joint.damper = 20f;
            joint.massScale = 4.5f;
        }
    }


   

    void shootGrapple()
    {
        //shoot.Play();
    }


   
    public void StopGrapple()
    {
        lr.positionCount = 0;
        isGrapple = false;
        Destroy(joint);
    }


    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }


}