using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightRaycaster : MonoBehaviour
{
    public static FlashlightRaycaster Singleton;

    private void Awake()
    {
        Singleton = this;
    }

    public IEnumerable<Enemy> TryRaycastEnemy()
    {
        List<Enemy> enemies = new List<Enemy>();
        Debug.DrawRay(transform.position, transform.forward, Color.red, 2f);
        var hits = Physics.RaycastAll(transform.position, transform.forward, float.PositiveInfinity);
        foreach (var hit in hits)
        {
            if (hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
                enemies.Add(enemy);
        }
        return enemies;
    }
}
