using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
public class Player : MonoBehaviour
{
    [Header("Rotation settings")]
    public List<float> RotationAngles;
    public int DefaultAngleIndex = 1;
    [Range(0f, 5f)] public float RotationSpeed = 1f;

    public static Player Singleton { get; private set; }

    public int CurrentRotationIndex { get; private set; }

    private Quaternion targetRotation;

    private void Awake()
    {
        Singleton = this;
        CurrentRotationIndex = DefaultAngleIndex;
        RotateCamera(DefaultAngleIndex);
    }

    private void Update()
    {
        if (transform.localRotation.y != targetRotation.y)
        {
            float y = Mathf.LerpAngle(transform.localEulerAngles.y, targetRotation.eulerAngles.y, Time.deltaTime * RotationSpeed);
            transform.localRotation = Quaternion.Euler(0f, y, 0f);
        }
    }

    public void RotateCamera(int index)
    {
        if (index < 0 || index >= RotationAngles.Count)
            return;

        targetRotation = Quaternion.Euler(0f, RotationAngles[index], 0f);
        CurrentRotationIndex = index;
    }
}
 