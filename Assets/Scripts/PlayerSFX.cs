using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip flashlightOn;
    [SerializeField] private AudioClip flashlightOff;
    
    public void PlayFlashlightOn()
    {
        audioSource.PlayOneShot(flashlightOn);
    }
    
    public void PlayFlashlightOff()
    {
        audioSource.PlayOneShot(flashlightOff);
    }
}