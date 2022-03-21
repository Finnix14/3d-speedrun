using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    public Image stamina_Stats;

    public void Display_StaminaStats(float staminaValue)
    {
        staminaValue /= 100f;

        stamina_Stats.fillAmount = staminaValue;

    }

}