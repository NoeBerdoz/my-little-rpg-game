using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private WeaponInfo weaponInfo;
    
    private PlayerControls playerControls;

    private InputAction touchPressAction;

    private void Awake()
    {
        playerControls = new PlayerControls();
        // touchPressAction = playerControls.FindAction("Mobile");
        touchPressAction = playerControls.Inventory.Mobile;
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Debug.Log("CONTEXT -----------------------");
        Debug.Log(context.ReadValueAsObject());

    }

    private void Start()
    {
        playerControls.Inventory.Mobile.performed += debugMe;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition;

        }
    }

    private void debugMe(InputAction.CallbackContext debug)
    {
        Debug.Log("[+] DEBUG VALUE IS: ");
        Debug.Log(debug);
    }
    
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
}
