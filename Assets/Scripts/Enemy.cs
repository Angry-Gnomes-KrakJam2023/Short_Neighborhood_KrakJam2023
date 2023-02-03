using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : Entity, IMovable
{
    public float MoveSpeed { get; set; }

    private Vector3 targetPosition = Vector3.zero;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.position != targetPosition)
            rb.position = Vector3.MoveTowards(rb.position, targetPosition, MoveSpeed);
    }

    public void Move(Vector3 pos)
    {
        targetPosition = pos;
    }
}
