using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private int health;

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
}
