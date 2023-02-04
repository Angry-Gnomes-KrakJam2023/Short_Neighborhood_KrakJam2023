using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AmbientPlayer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> windHowls = new();
    [SerializeField] private AudioSource audioSource;
    
    void Awake()
    {
        StartCoroutine(PlayWindHowl());
    }

    private IEnumerator PlayWindHowl()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 60f));
            audioSource.PlayOneShot(windHowls[Random.Range(0, windHowls.Count)]);
        }
    }
}
