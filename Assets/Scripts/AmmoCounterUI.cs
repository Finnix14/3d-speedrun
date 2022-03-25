using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AmmoCounterUI : MonoBehaviour
{

    [SerializeField] TMP_Text ammoCountershotgun;
    [SerializeField] TMP_Text ammoCounterpistol;

    [SerializeField] GameObject shotgunObj;
    [SerializeField] GameObject pistolObj;

    [SerializeField] Shotgun shotgun;
    [SerializeField] Pistol pistol;


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
        if (pistolObj.activeInHierarchy)
            ammoCounterpistol.text = string.Format("{0}/{1}", pistol.currentAmmo, pistol.maxAmmo);
        else
            ammoCounterpistol.text = string.Empty;
    }





}