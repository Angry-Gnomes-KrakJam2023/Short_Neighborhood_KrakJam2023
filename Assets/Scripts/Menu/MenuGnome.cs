using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MenuGnome : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private List<AudioClip> laughs;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        animator.Play("AngryJumping", 0, Random.Range(0f, 1f));
        StartCoroutine(RandomLaughs());
    }

    IEnumerator RandomLaughs()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3f, 15f));
            audioSource.PlayOneShot(laughs[Random.Range(0, laughs.Count)]);
        }
    }
}
