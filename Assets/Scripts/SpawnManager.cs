using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Singleton {get; private set;}
    private bool isSpawning = true;
    [SerializeField] private float timeToSpawn = 10f;

    private List<Spawner> spawners = new();

    private void Awake()
    {
        if (!Singleton)
            Singleton = this;
        else
            Destroy(gameObject);

        spawners.AddRange(FindObjectsOfType<Spawner>());

        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        if (spawners.Count == 0)
        {
            Debug.LogWarning(name + " - There is no spawners in list!");
            yield break;
        }

        while (isSpawning)
        {
            yield return new WaitForSeconds(timeToSpawn);
            int randomSpawner = Random.Range(0, spawners.Count);
            // TODO check if room is lit
            spawners[randomSpawner].Spawn();
        }
    }
}
