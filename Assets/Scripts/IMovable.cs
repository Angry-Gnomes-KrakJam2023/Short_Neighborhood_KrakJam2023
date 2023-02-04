using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    float MoveSpeed { get; set; }

    void Move(Vector3 pos);
}
