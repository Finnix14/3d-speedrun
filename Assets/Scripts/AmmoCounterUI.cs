using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AmmoCounterUI : MonoBehaviour
{

    [SerializeField] TMP_Text ammoCountershotgun;

    [SerializeField] GameObject shotgunObj;

    [SerializeField] Shotgun shotgun;


    void Update()
    {
        ShotgunUI();
    
    }


    void ShotgunUI()
    {
        if (shotgunObj.activeInHierarchy)
            ammoCountershotgun.text = string.Format("{0}/{1}", shotgun.currentAmmo, shotgun.maxAmmo);
        else
            ammoCountershotgun.text = string.Empty;
    }
    
    
    
    
 
}