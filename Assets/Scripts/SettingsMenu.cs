using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer theMixer;
    public static bool settingsEnabled;


    public Toggle fullscreenTog;
    public List<ResItem> resolutions = new List<ResItem>();

    private int selectedResolution;

    public TMP_Text mastLabel, musicLabel, sfxLabel;

    public Slider masterSlider, musicSlider, sfxSlider;

    void Start()
    {


        fullscreenTog.isOn = Screen.fullScreen;


        float vol = 0f;
        theMixer.GetFloat("MasterVol", out vol);
        masterSlider.value = vol;
        mastLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        theMixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

    
    }
  
   

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    public void SetMasterVolume()
    {
        mastLabel.text = Mathf.RoundToInt(masterSlider.value + 80).ToString();

        theMixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol", masterSlider.value);
    }
    public void SetMusicVolume()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();

        theMixer.SetFloat("MusicVol", musicSlider.value);

        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);
    }
    public void SetSFXVolume()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();

        theMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
    public void ApplyGraphics()
    {
        Screen.fullScreen = fullscreenTog.isOn;

       // Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical, fullscreenTog.isOn);
    }

}



[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}