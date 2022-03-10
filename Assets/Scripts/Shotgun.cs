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
    float fireRate = 0.5f;
    float nextTimeToFire;



    void Start()
    {
        col = GetComponent<CapsuleCollider>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
        {
            StartCoroutine("Propell");
        }
    }

    IEnumerator Propell()
    {
        nextTimeToFire = Time.time + fireRate;
        anim.SetBool("fireRate", true);
        muzzleflash.Play();
        shoot.Play();
        playerRig.AddForce(Camera.main.transform.forward * launchForce, ForceMode.VelocityChange);
        yield return new WaitForSeconds(1);
    }

}
