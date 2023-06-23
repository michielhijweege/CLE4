using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class settingsmenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public TMP_Dropdown qualityDropdown;

    public Slider master;
    public Slider music;
    public Slider sound;

    public Toggle toggle;

    public TMP_Dropdown reslutionDropdown;

    Resolution[] resolutions;

    public float volume;


    // krijg alle opgeslagen settings en zet deze correct  
    void Start()
    {
        resolutions = Screen.resolutions;

        reslutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = PlayerPrefs.GetInt("resolution" , 1);
            }
        }

        reslutionDropdown.AddOptions(options);
        reslutionDropdown.value = currentResolutionIndex;
        reslutionDropdown.RefreshShownValue();

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality", 1));
        qualityDropdown.value = PlayerPrefs.GetInt("qualitytext", QualitySettings.GetQualityLevel());


        toggle.isOn = PlayerPrefs.GetInt("fullscreen") == 1;

        master.value = PlayerPrefs.GetFloat("volume", 0f);
        audioMixer.SetFloat("Master", PlayerPrefs.GetFloat("volume"));
        music.value = PlayerPrefs.GetFloat("volume1", 0f);
        audioMixer.SetFloat("Music", PlayerPrefs.GetFloat("volume1"));
        sound.value = PlayerPrefs.GetFloat("volume2", 0f);
        audioMixer.SetFloat("SFX", PlayerPrefs.GetFloat("volume2"));
    }

    // zet de volume van master en sla deze op
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Master", volume);

        PlayerPrefs.SetFloat("volume", volume);
    }

    // zet de volume van music en sla deze op
    public void SetVolume1(float volume)
    {
        audioMixer.SetFloat("Music", volume);

        PlayerPrefs.SetFloat("volume1", volume);
    }

    // zet de volume van sfx en sla deze op
    public void SetVolume2(float volume)
    {
        audioMixer.SetFloat("SFX", volume);

        PlayerPrefs.SetFloat("volume2", volume);
    }

    // verander tussen full screen aan of uit
    public void fullscreen()
    {
        if (toggle.isOn) {
            Screen.fullScreen = true;
            PlayerPrefs.SetInt("fullscreen", 1);
        }
        else {
            Screen.fullScreen = false;
            PlayerPrefs.SetInt("fullscreen", 0);
        }
    }

    // set de quality en sla deze op
    public void setquality(int qualityindex)
    {
        QualitySettings.SetQualityLevel(qualityindex);
        PlayerPrefs.SetInt("quality", QualitySettings.GetQualityLevel());
        PlayerPrefs.SetInt("qualitytext", QualitySettings.GetQualityLevel());
    }

    // set de resolution en sla deze op
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("resolution", resolutionIndex);
    } 
}
