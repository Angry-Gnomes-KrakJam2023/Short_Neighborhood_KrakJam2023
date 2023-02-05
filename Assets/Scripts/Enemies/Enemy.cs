using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Entity, IAttacking, IFlashlightVulnerable
{
    [Header("Enemy Properties")]
    public int Damage = 1;
    [Header("Sprites")]
    public Sprite IdleFrame;
    public Sprite PrepareFrame;
    public Sprite AttackFrame;
    [Header("Sounds")]
    private AudioSource audioSource;
    public List<AudioClip> spawnSFX = new();
    public AudioClip chopSound;
    public AudioClip rootDestroySFX;

    public Target Target { get; set; }
    public Action OnKill { get; set; }
    public LightTypes VulnerableType { get; set; } = LightTypes.Normal;

    private SpriteRenderer sr;
    private ParticleSystem dissapearParticles;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(spawnSFX[Random.Range(0, spawnSFX.Count)]);

        sr = GetComponent<SpriteRenderer>();
        dissapearParticles = transform.parent.GetComponentInChildren<ParticleSystem>();
        Idle();
        OnKill += () => {
            // TODO: Runaway animation
            dissapearParticles.transform.parent = null;
            dissapearParticles.Play();
            //StartCoroutine(throwDissapearParticles(0.3f));
            audioSource.PlayOneShot(rootDestroySFX);
            DestroyMe(0.3f);
        };
        OnDeath += () => {
            // TODO: Proper death handling
            dissapearParticles.transform.parent = null;
            dissapearParticles.Play();
            //StartCoroutine(throwDissapearParticles(0f));
            Player.Singleton.PlayEnemyKillSound();
            DestroyMe(0f);
        };
    }

    public void Attack()
    {
        if (Target != null)
        {
            Target.Health -= Damage;
            audioSource.PlayOneShot(chopSound);
            if (Target.Health <= 0)
                OnKill?.Invoke();
        }
        sr.sprite = AttackFrame;
    }
    public void PrepareAttack()
    {
        sr.sprite = PrepareFrame;
    }
    public void Idle()
    {
        sr.sprite = IdleFrame;
    }

    IEnumerator throwDissapearParticles(float delay)
    {
        yield return new WaitForSeconds(delay);
        dissapearParticles.Play();
    }
}
