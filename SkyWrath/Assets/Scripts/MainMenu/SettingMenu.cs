using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer MasterMixer;
    public AudioMixer SFXMixer;
    public AudioMixer NusicMixer;
    public TMP_Dropdown ResolutionDropDown;
    public TMP_Dropdown GraphicsDropDown;

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
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume (float volume) //Alon
    {

    }

    public void Mute() //Alon
    {
        
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
