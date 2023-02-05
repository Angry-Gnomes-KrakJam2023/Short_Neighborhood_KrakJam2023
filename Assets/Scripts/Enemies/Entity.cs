using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private int health;

    public Action OnDeath { get; set; }
    public Action OnHit { get; set; }
    public int Health
    {
        get => health;
        set
        {
            if (value <= 0)
                OnDeath?.Invoke();
            else if(value < health)
                OnHit?.Invoke();

            health = value;
        }
    }

    public void DestroyMe(float time)
    {
        if(transform.parent != null)
            Destroy(transform.parent.gameObject, time);
        else
            Destroy(gameObject, time);
    }
}
