using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
public class Player : MonoBehaviour
{
    [Header("Rotation settings")]
    public List<float> RotationAngles;
    public int DefaultAngleIndex = 1;
    [Range(8f, 20f)] public float RotationSpeed = 1f;
    
    private AudioSource audioSource;
    public AudioClip enemyDieSFX;

    public static Player Singleton { get; private set; }

    public int CurrentRotationIndex { get; private set; }
    public int RoomID => CurrentRotationIndex;

    private Quaternion targetRotation;
    private const float epsilon = 0.5f;

    private void Awake()
    {
        Singleton = this;
        audioSource = GetComponent<AudioSource>();
        CurrentRotationIndex = DefaultAngleIndex;
        RotateCamera(DefaultAngleIndex);
    }

    private void Update()
    {
        if (Mathf.Abs(transform.localEulerAngles.y - targetRotation.eulerAngles.y) > epsilon)
        {
            float y = Mathf.LerpAngle(transform.localEulerAngles.y, targetRotation.eulerAngles.y, Time.deltaTime * RotationSpeed);
            transform.localRotation = Quaternion.Euler(0f, y, 0f);
            Flashlight.Singleton.IsBlocked = true;
        }
        else if (Flashlight.Singleton.IsBlocked)
            Flashlight.Singleton.IsBlocked = false;
    }

    public void RotateCamera(int index)
    {
        if (index < 0 || index >= RotationAngles.Count)
            return;

        targetRotation = Quaternion.Euler(0f, RotationAngles[index], 0f);
        CurrentRotationIndex = index;
    }

    public void PlayEnemyKillSound()
    {
        audioSource.PlayOneShot(enemyDieSFX);
    }
}
 