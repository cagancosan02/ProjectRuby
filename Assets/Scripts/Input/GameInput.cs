using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    Inputs playerInputs;
    public event EventHandler OnJumpAction;
    public event EventHandler OnShootAction;
    public event Action<int> OnSlotsAction;

    private void Awake()
    {
        playerInputs = new();
        playerInputs.Enable();

        playerInputs.Player.Jump.performed += Jump;
        playerInputs.Player.Slots.performed += Slots;
        playerInputs.Player.Shoot.started += Shoot;
    }

    public Vector2 GetLookVector()
    {
        Vector2 inputVector = playerInputs.Player.Look.ReadValue<Vector2>();

        return inputVector;
    }

    public Vector2 GetMovementNormalized()
    {
        Vector2 inputVector = playerInputs.Player.Movement.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        OnJumpAction?.Invoke(this, EventArgs.Empty);
    }

    public void Slots(InputAction.CallbackContext ctx)
    {
        int slotValue = Convert.ToInt32(ctx.control.name);

        OnSlotsAction?.Invoke(slotValue-1);
    }

    #region WEAPON
    public void Shoot(InputAction.CallbackContext ctx)
    {
        OnShootAction?.Invoke(this, EventArgs.Empty);
    }

    #endregion
}
