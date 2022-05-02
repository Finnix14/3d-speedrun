using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    public GameObject grappleimg;
    public GameObject shotgunimg;


    public GrapplingGun grapple;
    public Shotgun shotgun;


    public bool srReload;
    void Start()
    {
        selectWeapon();

        srReload = true;
    
        grappleimg.SetActive(true);
        shotgunimg.SetActive(false);
   

    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (Time.timeScale == 1)
        {
   
            if (Input.GetKeyDown(KeyCode.Alpha1) && transform.childCount >= 1)
            {
         
     
                grappleimg.SetActive(true);
                shotgunimg.SetActive(false);
            
                selectedWeapon = 1;
        


            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
            {

                grappleimg.SetActive(false);
                shotgunimg.SetActive(true);
       
                selectedWeapon = 2;
                grapple.StopGrapple();
        
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
