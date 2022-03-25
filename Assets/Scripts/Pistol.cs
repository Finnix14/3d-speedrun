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

    public int maxAmmo = 8;
    public int currentAmmo = 0;
    public float reloadTime = 1.2f;

    private bool isReloading = false;
    public Animator animator;
    public AudioSource reload;


    [SerializeField] int damage = 100;
    [SerializeField] int range = 100;
    [SerializeField] Camera fpsCam;


    void Start()
    {
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
                animator.SetTrigger("GunShoot");
                nextTimeToFire = Time.time + fireRate;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                if (currentAmmo <= 7)
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
            animator.SetTrigger("Reload");
            yield return new WaitForSeconds(reloadTime - .25f);
            yield return new WaitForSeconds(.25f);
            currentAmmo = maxAmmo;
            isReloading = false;
        }
    }

    void Shoot()
    {
        if (isReloading == false)
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


    void ReloadSFX()
    {
        reload.Play();
    }
}
