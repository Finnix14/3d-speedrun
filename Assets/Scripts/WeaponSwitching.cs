using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    Animator anim;
    void Start()
    {
        selectWeapon();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
           
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;

            
            else
                
            selectedWeapon++;
           
        } 
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            
            if (selectedWeapon >= transform.childCount - 2)
                selectedWeapon = 0;
                
            else
                
            selectedWeapon--;
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            selectedWeapon = 0;
            

        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&& transform.childCount>= 2)
        {
            
            selectedWeapon = 1;
               
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
            
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            KnifeSpin();
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
    void KnifeSpin()
    {
            anim.Play("weaponflip");
    }



}
