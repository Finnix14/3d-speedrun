using UnityEngine.Audio;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer mainMixer;
    public GameObject settingsmenu;
    public GameObject mainmenu;
    public static bool settingsEnabled;

    void Start()
    {
        settingsmenu.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("Volume", volume);
    }
    
    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void BackToPauseMenu()
    {
        settingsmenu.SetActive(false);
        mainmenu.SetActive(true);
        settingsEnabled = false;
    }
 
}
