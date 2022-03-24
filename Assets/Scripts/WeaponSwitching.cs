using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    Animator anim;
    public GameObject knifeimg;
    public GameObject grappleimg;
    public GameObject shotgunimg;


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
        knifeimg.SetActive(true);
        grappleimg.SetActive(false);
        shotgunimg.SetActive(false);
        

    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            knifeEquip.Play();
            selectedWeapon = 0;
            knifeimg.SetActive(true);
            grappleimg.SetActive(false);
            shotgunimg.SetActive(false);
            grapple.StopGrapple();
          
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            knifeEquip.Stop();
            shotgunEquip.Stop();
            knifeimg.SetActive(false);
            grappleimg.SetActive(true);
            shotgunimg.SetActive(false);
            selectedWeapon = 1;
            grappleEquip.Play();
        

        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
        
            knifeEquip.Stop();
            grappleEquip.Stop();
            knifeimg.SetActive(false);
            grappleimg.SetActive(false);
            shotgunimg.SetActive(true);
            selectedWeapon = 2;
            grapple.StopGrapple();
            shotgunEquip.Play();
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
