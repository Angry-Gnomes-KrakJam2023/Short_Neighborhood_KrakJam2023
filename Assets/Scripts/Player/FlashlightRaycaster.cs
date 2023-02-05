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

    public IEnumerable<Entity> TryRaycastEnemyOrDistractor()
    {
        List<Entity> enemies = new List<Entity>();
        Debug.DrawRay(transform.position, transform.forward, Color.red, 2f);
        var hits = Physics.RaycastAll(transform.position, transform.forward, float.PositiveInfinity);
        foreach (var hit in hits)
        {
            if (hit.transform.TryGetComponent<Enemy>(out Enemy enemy))
                enemies.Add(enemy);
            if (hit.transform.TryGetComponent<Distractor>(out Distractor distractor))
                enemies.Add(distractor);    
        }
        return enemies;
    }
}
