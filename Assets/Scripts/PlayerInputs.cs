using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputs : MonoBehaviour
{
    private const float inputEpsilon = 0.5f;
    [SerializeField] private GameObject[] flashlights = new GameObject[2];
    [SerializeField] private PlayerSFX playerSFX;
    private int currentFlashlight = 0;
    private bool flashlightOn = false;

    public void RotateCamera(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        
        float value = context.ReadValue<float>();
        if (value >= inputEpsilon)
            Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex + 1);
        else if (value <= -0.5f)
            Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex - 1);
    }
    
    public void ToggleFlashlight(InputAction.CallbackContext context)
    {
        if (!context.performed || !GameState.Singleton.IsPlaying)
            return;

        Flashlight.Singleton.gameObject.SetActive(!Flashlight.Singleton.gameObject.activeSelf);
    }
    
    public void Focus(InputAction.CallbackContext context)
    {
        if (!GameState.Singleton.IsPlaying)
            return;
        
        if (context.started)
            Flashlight.Singleton.Focus();
        else if (context.canceled)
            Flashlight.Singleton.Defocus();
    }

    public void MoveFlashlight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            
        }
    }
}
