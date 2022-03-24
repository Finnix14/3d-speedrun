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
    public AudioSource reloadingpistol;

    public int maxAmmo = 10;
    public int currentAmmo = 0;
    public float reloadTime = 2f;
    public bool isReloading = false;
    float fireRate = 0.08f;
    float nextTimeToFire;

    public PlayerMovement playermove;


    [SerializeField] int damage = 10;
    [SerializeField] int range = 100;
    [SerializeField] Camera fpsCam;

    public ParticleSystem muzzleflash;

    public bool isGrapple;

    public float launchForce;
    public Rigidbody playerRig;
    public Animator anim;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        anim = GetComponent<Animator>();
        shoot = GetComponent<AudioSource>();
        isGrapple = false;
       
    }
    void Start()
    {  if (currentAmmo == -1) 
        currentAmmo = maxAmmo;


    }

    void Update()
    {


        if (isReloading)
            return;
        {
            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Time.timeScale == 1)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    StartGrapple();

                }
                else if (Input.GetMouseButtonUp(1))
                {
                    StopGrapple();

                }

                if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
                {
                    Shoot();
                    nextTimeToFire = Time.time + fireRate;
                }
                if (Input.GetKeyDown(KeyCode.R))
                {
                    if (currentAmmo <= 9)
                    {
                        StartCoroutine(Reload());
                        return;
                    }

                }
            } 
        }
         
    }


    void LateUpdate()
    {
        DrawRope();
    }


    void StartGrapple()
    {
        RaycastHit hit;
        shootGrapple();
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            isGrapple = true;
            shoot.Play();
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

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    void Shoot()
    {
        if(currentAmmo >= 1)
        {
            if (isGrapple == false)
            {
                anim.SetTrigger("Shoot");
                muzzleflash.Play();
                currentAmmo--;
                gunshoot.Play();
                playerRig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
                RaycastHit hitInfo;
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitInfo, range))
                {

                    Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(damage);
                    }
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentAmmo <= 9)
            {
                StartCoroutine(Reload());
                return;
            }

        }

    }

    void KnifeInspect()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            anim.Play("spin");
        }
    }

    void KnifeSpin()
    {
        if (Input.GetKey(KeyCode.F))
        {
            anim.Play("knifespin");
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

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
    public IEnumerator Reload()
    {
        Debug.Log("Reloading");
        if (playermove.isGrounded)
        {
            isReloading = true;
            anim.SetTrigger("Reloading");
            yield return new WaitForSeconds(reloadTime - .25f);
            yield return new WaitForSeconds(.25f);
          
            currentAmmo = maxAmmo;
            isReloading = false;
        }
    }
    public void pistolreloading()
    {
        reloadingpistol.Play();
    }

}