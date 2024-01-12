using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    Inputs playerInputs;

    public bool IsJumping
    {
        get
        {
            return _isJumping;
        }
    }

    public bool IsSlot1
    {
        get
        {
            return _slot1;
        }
    }
    public bool IsSlot2
    {
        get
        {
            return _slot2;
        }
    }
    private bool _isJumping = false;
    private bool _slot1, _slot2 = false;
    private void Awake()
    {
        playerInputs = new();
        playerInputs.Enable();

        playerInputs.Player.Jump.performed += Jump;
        playerInputs.Player.Jump.canceled += Jump;
        playerInputs.Player.Slot1.performed += Slot1;
        playerInputs.Player.Slot1.canceled += Slot1;
        playerInputs.Player.Slot2.performed += Slot2;
        playerInputs.Player.Slot2.canceled += Slot2;
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
        switch (ctx.phase)
        {
            case InputActionPhase.Performed:
                _isJumping = true;
                break;
            case InputActionPhase.Canceled:
                _isJumping = false;
                break;
        }
    }

    public void Slot1(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Performed:
                _slot1 = true;
                break;
            case InputActionPhase.Canceled:
                _slot1 = false;
                break;
        }
    }

    public void Slot2(InputAction.CallbackContext ctx)
    {
        switch (ctx.phase)
        {
            case InputActionPhase.Performed:
                _slot2 = true;
                break;
            case InputActionPhase.Canceled:
                _slot2 = false;
                break;
        }
    }
}
