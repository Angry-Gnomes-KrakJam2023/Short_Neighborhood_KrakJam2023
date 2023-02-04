using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public static Flashlight Singleton { get; private set; }

    public bool IsFocused { get; private set; } = false;

    private Light flashlight_light;
    private const float focusIntensityMultiplier = 2f;
    private const float focusAngleMultiplier = 0.3f;

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
        if(!IsFocused)
            return;

        var enemies = FlashlightRaycaster.Singleton.TryRaycastEnemy();
        foreach (var enemy in enemies)
        {
            enemy.Health--;
        }
    }

    public void Focus()
    {
        if (IsFocused)
            return;

        IsFocused = true;
        flashlight_light.intensity *= focusIntensityMultiplier;
        flashlight_light.spotAngle *= focusAngleMultiplier;
    }

    public void Defocus()
    {
        if (!IsFocused)
            return;

        IsFocused = false;
        flashlight_light.intensity /= focusIntensityMultiplier;
        flashlight_light.spotAngle /= focusAngleMultiplier;
    }
}
