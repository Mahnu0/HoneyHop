using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerManager : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider BGMVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    private void Start()
    {
        if(PlayerPrefs.HasKey("initialMasterVolume"))
        {
            LoadMasterVolume();
        }
        if (PlayerPrefs.HasKey("initialBGMVolume"))
        {
            LoadBMGVolume();
        }
        if (PlayerPrefs.HasKey("initialSFXVolume"))
        {
            LoadSFXVolume();
        }
    }

    public void SetMasterVolume(float level)
    {
        float volume = masterVolumeSlider.value;
        audioMixer.SetFloat("masterVolume", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("initialMasterVolume", volume);
    }

    public void SetBGMVolume(float level)
    {
        float volume = BGMVolumeSlider.value;
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("initialBGMVolume", volume);
    }

    public void SetSFXVolume(float level)
    {
        float volume = SFXVolumeSlider.value;
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(level) * 20f);
        PlayerPrefs.SetFloat("initialSFXVolume", volume);
    }

    private void LoadMasterVolume()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("initialMasterVolume");
    }

    private void LoadBMGVolume()
    {
        BGMVolumeSlider.value = PlayerPrefs.GetFloat("initialBGMVolume");
    }

    private void LoadSFXVolume()
    {
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("initialSFXVolume");
    }
}
