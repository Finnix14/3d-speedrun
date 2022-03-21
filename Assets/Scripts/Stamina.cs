using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Stamina : MonoBehaviour
{
    public float stamina;
    float maxstamina;

    public Slider staminaBar;
    public float dValue;
    void Start()
    {
        maxstamina = stamina;
        staminaBar.maxValue = maxstamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            DecreaseEnergy();
        else if (stamina != maxstamina)
            IncreaseEnergy();

        staminaBar.value = stamina;
    }

    public void DecreaseEnergy()
    {
        if (stamina != 0)
            stamina -= dValue * Time.deltaTime;
    }
    public void IncreaseEnergy()
    {
            stamina += dValue * Time.deltaTime;
    }
}

