using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public float AngleMinX = -30f;
    public float AngleMaxX = 30;
    public float AngleMinY = -30f;
    public float AngleMaxY = 30f;

    public static Flashlight Singleton { get; private set; }

    public bool IsFocused { get; private set; } = false;
    public bool IsBlocked 
    {
        get => isBlocked;
        set
        {
            isBlocked = value;
            if (isBlocked && IsFlashing)
            {
                ResetRotation();
                gameObject.SetActive(false);
                disabledByBlock = true;
            }
            if  (!isBlocked && disabledByBlock)
            {
                Toggle();
                disabledByBlock = false;
            }
        }
    }
    public bool IsFlashing => gameObject.activeSelf;

    private Light flashlight_light;
    private Vector3 angles = Vector3.zero;
    private bool isBlocked = false;
    private bool disabledByBlock = false;
    private const float focusIntensityMultiplier = 2f;
    private const float focusAngleMultiplier = 0.3f;
    private const float sensitivity = 0.05f;

    public Flashlight()
    {
        Singleton = this;
    }

    private void Awake()
    {
        flashlight_light = GetComponent<Light>();
    }

    private void FixedUpdate()
    {
        if(!IsFocused || IsBlocked)
            return;

        var enemies = FlashlightRaycaster.Singleton.TryRaycastEnemy();
        foreach (var enemy in enemies)
        {
            enemy.Health--;
        }
    }

    public void Focus()
    {
        if (IsFocused || IsBlocked || !IsFlashing)
            return;

        IsFocused = true;
        flashlight_light.intensity *= focusIntensityMultiplier;
        flashlight_light.spotAngle *= focusAngleMultiplier;
    }

    public void Defocus()
    {
        if (!IsFocused || IsBlocked || !IsFlashing)
            return;

        IsFocused = false;
        flashlight_light.intensity /= focusIntensityMultiplier;
        flashlight_light.spotAngle /= focusAngleMultiplier;
    }

    public void RotateFlashlight(float x, float y)
    {
        if (IsBlocked)
            return;

        angles += new Vector3(-y, x, 0f) * sensitivity;    
        angles.x = Mathf.Clamp(angles.x, AngleMinX, AngleMaxX);
        angles.y = Mathf.Clamp(angles.y, AngleMinY, AngleMaxY);

        transform.localEulerAngles = angles;
    }

    public void ResetRotation()
    {
        angles = Vector3.zero;
        transform.localEulerAngles = angles;
    }

    public void Toggle()
    {
        if(IsBlocked)
            return;

        if (!gameObject.activeSelf)
            ResetRotation();
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
