using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacking
{
    Target Target { get; set; }

    void PrepareAttack();
    void Attack();
    void Idle();
}
