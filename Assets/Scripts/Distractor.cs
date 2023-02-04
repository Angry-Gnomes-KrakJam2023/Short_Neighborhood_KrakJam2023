using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distractor : Entity, IMovable
{
    [SerializeField] private float moveSpeed;

    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    private SpriteRenderer sr;
    private ParticleSystem dissapearParticles;
    private Vector3 target;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        dissapearParticles = transform.parent.GetComponentInChildren<ParticleSystem>();
        OnDeath += () => {
            // TODO: Proper death handling
            dissapearParticles.transform.parent = null;
            dissapearParticles.Play();
            //StartCoroutine(throwDissapearParticles(0f));
            DestroyMe(0f);
        };

        Move(Player.Singleton.transform.position + Player.Singleton.transform.forward * 0.4f);
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    public void Move(Vector3 pos)
    {
        target = pos;
    }
}
