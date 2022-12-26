using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System;

[Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }

public class InputController : MonoBehaviour
{
    PlayerController controls;
    public MoveInputEvent moveInputEvent;

    private void Awake()
    {
        controls = new PlayerController();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Move.performed += OnMovePerformed;
        controls.Player.Move.canceled += OnMovePerformed;
    }

    void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
    }
}

