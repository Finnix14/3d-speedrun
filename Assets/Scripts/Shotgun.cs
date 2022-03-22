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
    float fireRate = 0.60f;
    float nextTimeToFire;

    public int maxAmmo = 2;
    private int currentAmmo = 0;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Animator animator;
    public AudioSource reload;




    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        shoot = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
        animator.SetBool("Shoot", false);
        animator.SetBool("Shoot2", false);
    }


    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (isReloading)
                return;

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
            {
                Shoot();
                anim.SetBool("Shoot",true);
                nextTimeToFire = Time.time + fireRate;
                
                

            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentAmmo <= 1)
                {
                    StartCoroutine(Reload());
                    return;
                }

            }
        }
    }
    
    
    public IEnumerator Reload()
    {
            anim.SetBool("Shoot", false);
           
            isReloading = true;
            animator.SetBool("Reloading", true); 
            yield return new WaitForSeconds(reloadTime - .25f);
            animator.SetBool("Reloading", false);
            yield return new WaitForSeconds(.25f);
            currentAmmo = maxAmmo;
            isReloading = false;
            
               
    }

   void Shoot()
   {
        anim.SetBool("Shoot2", true);
        currentAmmo--;
        muzzleflash.Play();
        shoot.Play();
        playerRig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
        
   }

    void ReloadSFX()
    {
        reload.Play();
    }

    

    
}
