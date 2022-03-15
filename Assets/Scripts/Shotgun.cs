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
    public Animator anim;
    public float launchForce;
    public ParticleSystem muzzleflash;
    public bool isShotgun = false;
    public AudioSource shoot;
    float fireRate = 0.35f;
    float nextTimeToFire;

    public int maxAmmo = 2;
    private int currentAmmo = 0;
    public float reloadTime = 1.2f;
    private bool isReloading = false;

    public Animator animator;
    public AudioSource reload;




    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }


    void Update()
    {
        if (isReloading)
            return;
        
        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            Shoot();
          
            nextTimeToFire = Time.time + fireRate;
           
        }


    }
    
    
    IEnumerator Reload()
    {
        if (player.isGrounded)
        {
            isReloading = true;
            animator.SetBool("Reloading", true);
            yield return new WaitForSeconds(reloadTime - .25f);
            animator.SetBool("Reloading", false);
            reload.Play();
            yield return new WaitForSeconds(.25f);
           

            currentAmmo = maxAmmo;
            isReloading = false;
        }        
    }

   void Shoot()
    {
        currentAmmo--;
        
        muzzleflash.Play();
        shoot.Play();
        playerRig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
       
       
    }
}
