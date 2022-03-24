using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AmmoCounterUI : MonoBehaviour
{
    [SerializeField] TMP_Text ammoCounterpistol;
    [SerializeField] TMP_Text ammoCountershotgun;
    [SerializeField] GameObject gunObj;
    [SerializeField] GameObject shotgunObj;
    [SerializeField] GrapplingGun gun;
    [SerializeField] Shotgun shotgun;


    void Update()
    {
        ShotgunUI();
        GunUI();
    }


    void ShotgunUI()
    {
        if (shotgunObj.activeInHierarchy)
            ammoCountershotgun.text = string.Format("{0}/{1}", shotgun.currentAmmo, shotgun.maxAmmo);
        else
            ammoCountershotgun.text = string.Empty;
    }
    
    
    
    
    void GunUI()
    {
        if (gunObj.activeInHierarchy)
            ammoCounterpistol.text = string.Format("{0}/{1}", gun.currentAmmo, gun.maxAmmo);
        else
            ammoCounterpistol.text = string.Empty;
  
    }
}