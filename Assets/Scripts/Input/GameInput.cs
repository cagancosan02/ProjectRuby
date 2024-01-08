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
    private bool _isJumping = false;
    private void Awake()
    {
        playerInputs = new();
        playerInputs.Enable();

        playerInputs.Player.Jump.performed += Jump;
                playerInputs.Player.Jump.canceled += Jump;

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
}
