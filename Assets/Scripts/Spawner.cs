using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform enemySpawnerLocation;

    public bool HasEnemy { get; private set; }

    public void Spawn()
    {
        if(HasEnemy) return;

        if (!enemyToSpawn)
        {
            Debug.LogWarning(name + " - There is no enemy attached to this spawner!");
            return;
        }

        if (!enemySpawnerLocation)
        {
            Debug.LogWarning(name + " - There is no enemySpawnerLocation set!");
            return;
        }

        Instantiate(enemyToSpawn, enemySpawnerLocation.position, Quaternion.identity, transform);
        HasEnemy = true;
    }
}
