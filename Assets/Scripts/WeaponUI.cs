using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Text magSizeText;
    [SerializeField] private Text magCountText;
    


   public void UpdateInfo(Sprite weaponIcon, int magazineSize, int magazineCount)
    {
        icon.sprite = weaponIcon;
        magSizeText.text = magazineSize.ToString();
        int magazineCountAmount = magazineSize * magazineCount;
        magCountText.text = magazineCountAmount.ToString();
    }
}
