using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputs : MonoBehaviour
{
    private const float inputEpsilon = 0.5f;
    [SerializeField] private GameObject[] flashlights = new GameObject[2];
    private int currentFlashlight = 0;
    private bool flashlightOn = false;

    public void RotateCamera(InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;
        
        float value = context.ReadValue<float>();
        if (value >= inputEpsilon)
            Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex + 1);
        else if (value <= -0.5f)
            Player.Singleton.RotateCamera(Player.Singleton.CurrentRotationIndex - 1);
    }

    private void SwitchFlashlight()
    {
        if (flashlightOn)
            flashlights[currentFlashlight].SetActive(false);
        else
            flashlights[currentFlashlight].SetActive(true);
        flashlightOn = !flashlightOn;
    }

    private void ChangeFlashlight(int number)
    {
        flashlights[currentFlashlight].SetActive(false);
        currentFlashlight = number;
        flashlights[currentFlashlight].SetActive(true);
    }
    
    public void ChooseFlashlight1(InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;

        if (currentFlashlight == 0)
            SwitchFlashlight();
        else
            ChangeFlashlight(0);
    }
    
    public void ChooseFlashlight2(InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;
        
        if (currentFlashlight == 1)
            SwitchFlashlight();
        else
            ChangeFlashlight(1);
    }
}
