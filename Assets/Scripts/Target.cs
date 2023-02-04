using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Entity
{
    private void Awake()
    {
        OnDeath += () => {
            Destroy(gameObject, 1f);
            GameState.Singleton.Lives--;
        }; // TODO: Improve death (animation etc.)
    }
}
