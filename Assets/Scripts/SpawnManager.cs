using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Singleton {get; private set;}
    private bool isSpawning = true;
    [SerializeField] private float timeToSpawn = 10f;

    private List<ISpawner> spawners = new ();

    private void Awake()
    {
        if (!Singleton)
            Singleton = this;
        else
            Destroy(gameObject);

        spawners.AddRange((ISpawner[])FindObjectsOfType<EnemySpawner>());
        spawners.AddRange((ISpawner[])FindObjectsOfType<DistractorSpawner>());

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
            IEnumerable<ISpawner> properSpawner = from spawner in spawners where !spawner.HasEnemy &&
                spawner.RoomID != Player.Singleton.RoomID select spawner;
            int count = properSpawner.ToList().Count;
            if(count <= 0)
                continue;

            int randomSpawner = Random.Range(0, count);
            // TODO check if room is lit
            properSpawner.ToList()[randomSpawner].Spawn();
        }
    }
}
