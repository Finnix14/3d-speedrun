using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    Animator anim;
    public GameObject grappleimg;
    public GameObject shotgunimg;
    public GameObject pistolimg;

    public GrapplingGun grapple;
    public Shotgun shotgun;

    public AudioSource shotgunEquip;
    public AudioSource knifeEquip;
    public AudioSource grappleEquip;

    public bool srReload;
    void Start()
    {
        selectWeapon();

        srReload = true;
    
        grappleimg.SetActive(true);
        shotgunimg.SetActive(false);
        pistolimg.SetActive(false);

    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Time.timeScale == 1)
        {
   
            if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1)
            {
               // knifeEquip.Stop();
              //  shotgunEquip.Stop();
     
                grappleimg.SetActive(true);
                shotgunimg.SetActive(false);
                pistolimg.SetActive(false);
                selectedWeapon = 1;
              //  grappleEquip.Play();


            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {

               // knifeEquip.Stop();
              //  grappleEquip.Stop();

                grappleimg.SetActive(false);
                shotgunimg.SetActive(true);
                pistolimg.SetActive(false);
                selectedWeapon = 2;
                grapple.StopGrapple();
              //  shotgunEquip.Play();
            }


            if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
            {

                grappleimg.SetActive(false);
                shotgunimg.SetActive(false);
                pistolimg.SetActive(true);
               // knifeEquip.Stop();
                //grappleEquip.Stop();
                selectedWeapon = 3;
                grapple.StopGrapple();
                //grappleEquip.Play();
            }
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
            
        }


    }


    void selectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;

        }
    }


 
  






}
