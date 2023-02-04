using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private int roomID;
    [SerializeField] private GameObject enemyToSpawn;
    [SerializeField] private Transform enemySpawnerLocation;

    public bool HasEnemy { get; set; }
    public int RoomID { get => roomID; set => roomID = value; }

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
