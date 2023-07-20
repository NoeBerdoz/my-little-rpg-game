using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    public MonoBehaviour CurrentActiveWeapon { get; private set; }
    
    private PlayerControls playerControls;
    private bool attackButtonDown, isAttacking = false;


    protected override void Awake()
    {
        base.Awake();
        
        playerControls = new PlayerControls();
    }
    
    private void OnEnable() {
        playerControls.Enable();
    }

    private void Start()
    {
        // Call Attack function on control input Attack
        playerControls.Combat.Attack.started += _ => StartAttacking(); // '_' synthax to not pass any parameters to the coming function
        playerControls.Combat.Attack.canceled += _ => StopAttacking();
    }

    private void Update()
    {
        Attack();
    }

    public void NewWeapon(MonoBehaviour newWeapon)
    {
        CurrentActiveWeapon = newWeapon;
    }

    public void WeaponNull()
    {
        CurrentActiveWeapon = null;
    }

    public void ToggleIsAttacking(bool value)
    {
        isAttacking = value;
    }

    private void StartAttacking() {
        attackButtonDown = true;
    }

    private void StopAttacking() {
        attackButtonDown = false;
    }

    private void Attack()
    {
        if (attackButtonDown && !isAttacking)
        {
            isAttacking = true;
        
            // Call the Attack() function from the correct class through the IWeapon interface
            (CurrentActiveWeapon as IWeapon).Attack();
        }
        
    }

}
