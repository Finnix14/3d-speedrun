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
    public int currentAmmo = 0;


    public Animator animator;

    public GameObject weaponUI;
    public ShotGunCollectable gunthrow;

    [SerializeField] int damage = 100;
    [SerializeField] int range = 100;
    [SerializeField] Camera fpsCam;

    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        shoot = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
      
       
    }


    void Update()
    {
        if (Time.timeScale == 1)
        {
          
            if (currentAmmo <= 0)
            {
                gunthrow.Drop();
                weaponUI.SetActive(false);
                return;
            }

            if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
            {
                Shoot();
                anim.SetTrigger("Shoot");
                nextTimeToFire = Time.time + fireRate;
            }

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
