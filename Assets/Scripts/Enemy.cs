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

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        Idle();
        OnKill += () => {
            // TODO: Runaway animation
            DestroyMe(0.3f);
        };
        OnDeath += () => {
            // TODO: Proper death handling
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
    public void DestroyMe(float time)
    {
        if(transform.parent != null)
            Destroy(transform.parent.gameObject, time);
        else
            Destroy(gameObject, time);
    }
}
