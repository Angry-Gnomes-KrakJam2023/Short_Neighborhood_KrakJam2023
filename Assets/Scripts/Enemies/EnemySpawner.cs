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

        Quaternion rotation = RoomID == 0 ? Quaternion.Euler(0f, -90f, 0f) : (RoomID == 1 ? Quaternion.identity : Quaternion.Euler(0f, 90f, 0f));

        Enemy enemy = Instantiate(enemyToSpawn, enemySpawnerLocation.position, rotation).GetComponentInChildren<Enemy>();
        enemy.Health = (int)(40 * GameState.Singleton.HealthMultiplier);
        enemy.Damage = GameState.Singleton.EnemyDamage;
        enemy.Target = GetComponent<Target>();
        enemy.OnDeath += () => HasEnemy = false;
        HasEnemy = true;
    }
}
