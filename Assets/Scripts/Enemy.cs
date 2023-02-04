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
    [Header("Attack timings")]
    public float IdleTime = 2f;
    public float PrepareTime = 4f;
    public float AttackTime = 1f;
    private enum TimeSpace
    {
        Idle,
        Prepare,
        Attack
    }

    public Target Target { get; set; }

    private SpriteRenderer sr;
    private float timer;
    private TimeSpace timeSpace;

    private void Awake()
    {
        timeSpace = TimeSpace.Idle;
        timer = IdleTime;
        sr = GetComponent<SpriteRenderer>();
        Idle();
        OnDeath += () => {
            // TODO: Proper death handling
            Destroy(gameObject, 1f);
        };
    }

    private void FixedUpdate()
    {
        if (!GameState.Singleton.IsPlaying)
            return;
        
        timer -= Time.fixedDeltaTime;
        if (timer <= 0f)
        {
            switch (timeSpace)
            {
                case TimeSpace.Idle:
                    timeSpace = TimeSpace.Prepare;
                    PrepareAttack();
                    timer = PrepareTime;
                    break;
                case TimeSpace.Prepare:
                    timeSpace = TimeSpace.Attack;
                    Attack();
                    timer = AttackTime;
                    break;
                case TimeSpace.Attack:
                    timeSpace = TimeSpace.Idle;
                    Idle();
                    timer = IdleTime;
                    break;
                default:
                    break;
            }
        }
    }

    public void Attack()
    {
        if(Target != null)
            Target.Health -= Damage;
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
}
