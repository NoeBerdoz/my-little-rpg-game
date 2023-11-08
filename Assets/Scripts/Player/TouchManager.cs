using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    // WORKAROUND TOUCH INPUTS
    // MAN I GOTA HANDLE THAT 
    // RTFM https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Touch.html
    
    [SerializeField] private GameObject player;
    
    private PlayerInput playerInput;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];

    }

    private void Update()
    {
        touchPositionAction.ReadValue<Vector2>();
        if (touchPressAction.WasPerformedThisFrame())
        {
            // move object to touch position
            Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
            position.z = player.transform.position.z;
            player.transform.position = position;
        }
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log(value);
    }
}
