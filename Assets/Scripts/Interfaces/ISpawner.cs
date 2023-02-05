using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawner
{
    bool HasEnemy { get; set; }
    int RoomID { get; set; }
    void Spawn();
}
