using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown ResolutionDropDown;
    public TMP_Dropdown GraphicsDropDown;
    
    [SerializeField] Slider MasterVolumeSlider;
    [SerializeField] Slider SFXVolumeSlider;
    [SerializeField] Slider MusicVolumeSlider;

    Resolution[] resolutions;
    private void Start()
    {
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        resolutions = Screen.resolutions;
        ResolutionDropDown.ClearOptions();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                    currentResolutionIndex = i;
        }

        ResolutionDropDown.AddOptions(options);
        ResolutionDropDown.value = currentResolutionIndex;
        ResolutionDropDown.RefreshShownValue();

        QualitySettings.SetQualityLevel(2);
        GraphicsDropDown.value = 2;
        GraphicsDropDown.RefreshShownValue();

        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetMasterVolume()
    {
        float volume = MasterVolumeSlider.value;
        audioMixer.SetFloat("master", Mathf.Log10(volume)*20);
    }

    public void SetMusicVolume()
    {
        float volume = MusicVolumeSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume)*20);
    }
    
    public void SetSFXVolume()
    {
        float volume = SFXVolumeSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume)*20);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}