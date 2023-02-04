using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity, IAttacking
{
    [Header("Enemy Properties")]
    public int Damage = 1;
    [Header("Sprites")]
    public Sprite IdleFrame;
    public Sprite PrepareFrame;
    public Sprite AttackFrame;

    public Target Target { get; set; }
    public Action OnKill { get; set; }

    private SpriteRenderer sr;
    private ParticleSystem dissapearParticles;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        dissapearParticles = transform.parent.GetComponentInChildren<ParticleSystem>();
        Idle();
        OnKill += () => {
            // TODO: Runaway animation
            dissapearParticles.transform.parent = null;
            dissapearParticles.Play();
            //StartCoroutine(throwDissapearParticles(0.3f));
            DestroyMe(0.3f);
        };
        OnDeath += () => {
            // TODO: Proper death handling
            dissapearParticles.transform.parent = null;
            dissapearParticles.Play();
            //StartCoroutine(throwDissapearParticles(0f));
            DestroyMe(0f);
        };
    }

    public void Attack()
    {
        if (Target != null)
        {
            Target.Health -= Damage;
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
