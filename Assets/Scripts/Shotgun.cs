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
    public float reloadTime = 1f;

    private bool isReloading = false;
    public Animator animator;
    public AudioSource reload;


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
        isReloading = false;
       
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
                anim.SetTrigger("Shoot");
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
        if (player.isGrounded)
        {
            isReloading = true;
            animator.SetTrigger("Reloading");
            yield return new WaitForSeconds(reloadTime - .25f);
            yield return new WaitForSeconds(.25f);
            currentAmmo = maxAmmo;
            isReloading = false;
        }
    }

    void Shoot()
    {
        anim.SetBool("Shoot", true);
        currentAmmo--;
        muzzleflash.Play();
        shoot.Play();
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
