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
    float fireRate = 0.3f;
    float nextTimeToFire;

    public int maxAmmo = 2;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;



    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        currentAmmo = maxAmmo;
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
        isReloading = true;
        Debug.Log("reload");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

   void Shoot()
    {
        currentAmmo--;
        muzzleflash.Play();
        shoot.Play();
        playerRig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
       
    }
}
