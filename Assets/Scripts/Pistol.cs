using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public ParticleSystem muzzleflash;
    public AudioSource shoot;
    float fireRate = 0.6f;
    float nextTimeToFire;

    public PlayerMovement player;

    public int maxAmmo = 6;
    public int currentAmmo = 0;


    public GameObject weaponUI;
    public RevolverThrow gunthrow;

    public Animator animator;
    

    Ray ray;

    public float damage = 100;
    [SerializeField] int range = 100;
    [SerializeField] Camera fpsCam;

    void Start()
    {
        currentAmmo = maxAmmo;
    }
 

    void Update()
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
            animator.SetTrigger("GunShoot");
            nextTimeToFire = Time.time + fireRate;
        }
     
    }
    void Shoot()
    {


        currentAmmo--;
        muzzleflash.Play();
        shoot.Play();
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





