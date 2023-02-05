using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistractorSpawner : MonoBehaviour, ISpawner
{
    [SerializeField] private int roomID;

    [SerializeField] private GameObject distractorToSpawn;

    public bool HasEnemy { get; set; }
    public int RoomID { get => roomID; set => roomID = value; }

    public void Spawn()
    {
        if(HasEnemy) return;

        if (!distractorToSpawn)
        {
            Debug.LogWarning(name + " - There is no enemy attached to this spawner!");
            return;
        }

        Quaternion rotation = RoomID == 0 ? Quaternion.Euler(0f, -90f, 0f) : (RoomID == 1 ? Quaternion.identity : Quaternion.Euler(0f, 90f, 0f));

        Distractor enemy = Instantiate(distractorToSpawn, transform.position + new Vector3(0f, 1f, 0f), rotation).GetComponentInChildren<Distractor>();
        enemy.OnDeath += () => HasEnemy = false;
        HasEnemy = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, Vector3.up));
    }
}
