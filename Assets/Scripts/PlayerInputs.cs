using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputs : MonoBehaviour
{
    private const float inputEpsilon = 0.5f;

    public void RotateCamera(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            float value = context.ReadValue<float>();
            if (value >= inputEpsilon)
                Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex + 1);
            else if (value <= -0.5f)
                Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex - 1);
        }
    }
}
