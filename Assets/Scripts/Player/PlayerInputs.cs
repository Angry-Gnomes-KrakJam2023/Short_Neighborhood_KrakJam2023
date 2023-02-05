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
        if (!context.performed)
            return;
        
        if (GameState.paused)
            return;

        float value = context.ReadValue<float>();
        if (value >= inputEpsilon)
            Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex + 1);
        else if (value <= -0.5f)
            Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex - 1);
    }

    public void Focus(InputAction.CallbackContext context)
    {
        if (!GameState.Singleton.IsPlaying)
            return;
        
        if (GameState.paused)
            return;

        if (context.started)
            Flashlight.Singleton.Focus();
        else if (context.canceled)
            Flashlight.Singleton.Defocus();
    }

    public void MoveFlashlight(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (GameState.paused)
            return;

        var value = context.ReadValue<Vector2>();
        Flashlight.Singleton.RotateFlashlight(value.x, value.y);
    }

    public void ChangeFlashlightMode(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        if (GameState.paused)
            return;
        
        Flashlight.Singleton.ToggleMode();
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (GameState.paused)
            GameState.Singleton.ResumeGame();
        else
            GameState.Singleton.PauseGame();
    }
}