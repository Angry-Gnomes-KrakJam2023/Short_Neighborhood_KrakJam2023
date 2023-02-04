using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Entity
{
    private void Awake()
    {
        OnDeath += () => {
            StartCoroutine(DestroyAfterDelay());
        }; // TODO: Improve death (animation etc.)
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        GameState.Singleton.Lives--;
    }
}
