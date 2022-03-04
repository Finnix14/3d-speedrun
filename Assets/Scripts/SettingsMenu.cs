using UnityEngine.Audio;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer mainMixer;
    public GameObject settingsmenu;
    public GameObject pausemenu;


    void Start()
    {
        settingsmenu.SetActive(false);
    }
    public void SetVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
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
        pausemenu.SetActive(true);
    }
 
}
