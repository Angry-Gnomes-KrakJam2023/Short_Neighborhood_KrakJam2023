using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : Panel
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider ambientSlider;
    [SerializeField] private Slider sfxSlider;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    public override void ShowPanel()
    {
        base.ShowPanel();
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0.5f);
        ambientSlider.value = PlayerPrefs.GetFloat("ambientVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0.5f);
        
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        ambientSlider.onValueChanged.AddListener(delegate { SetAmbientVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public override void HidePanel()
    {
        base.HidePanel();
        PlayerPrefs.Save();
    }

    private void SetMusicVolume()
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log(musicSlider.value) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    
    private void SetAmbientVolume()
    {
        audioMixer.SetFloat("ambientVolume", Mathf.Log(ambientSlider.value) * 20);
        PlayerPrefs.SetFloat("ambientVolume", ambientSlider.value);
    }

    private void SetSFXVolume()
    {
        audioMixer.SetFloat("sfxVolume", Mathf.Log(sfxSlider.value) * 20);
        PlayerPrefs.SetFloat("sfxVolume", sfxSlider.value);
    }
}