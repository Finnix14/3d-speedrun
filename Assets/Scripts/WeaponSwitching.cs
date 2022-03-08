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
       
      


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            selectedWeapon = 0;
            

        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&& transform.childCount>= 2)
        {
            
            selectedWeapon = 1;

           
               
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }


        if (previousSelectedWeapon != selectedWeapon)
        {
            selectWeapon();
            
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            KnifeInspect();
        }

        if (Input.GetKeyDown(KeyCode.F))
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
    void KnifeInspect()
    {
        anim.Play("weaponflip");
            
    }

    void KnifeSpin()
    {
        anim.Play("knifespin");
    }

 
  






}
