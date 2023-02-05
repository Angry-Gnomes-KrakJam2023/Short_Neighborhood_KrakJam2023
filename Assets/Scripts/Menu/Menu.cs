using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int mainSceneNumber;
    [SerializeField] private AudioMixer audioMixer;
    
    public static Menu Singleton {get; private set;}

    void Awake()
    {
        if (!Singleton)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        audioMixer.SetFloat("musicVolume", Mathf.Log(PlayerPrefs.GetFloat("musicVolume", 0.5f)) * 20);
        audioMixer.SetFloat("ambientVolume", Mathf.Log(PlayerPrefs.GetFloat("ambientVolume", 0.5f)) * 20);
        audioMixer.SetFloat("sfxVolume", Mathf.Log(PlayerPrefs.GetFloat("sfxVolume", 0.5f)) * 20);
    }

    public void Play()
    {
        AsyncSceneLoader.Singleton.LoadScene(mainSceneNumber);
    }

    public void Quit()
    {
        Application.Quit();
    }
}