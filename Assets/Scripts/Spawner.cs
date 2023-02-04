using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int RoomID;

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

        Enemy enemy = Instantiate(enemyToSpawn, enemySpawnerLocation.position, Quaternion.identity).GetComponentInChildren<Enemy>();
        enemy.Target = GetComponent<Target>();
        enemy.OnDeath += () => HasEnemy = false;
        HasEnemy = true;
    }
}
