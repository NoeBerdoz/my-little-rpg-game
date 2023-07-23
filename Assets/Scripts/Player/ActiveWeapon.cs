using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeapon : Singleton<ActiveWeapon>
{
    public MonoBehaviour CurrentActiveWeapon { get; private set; }
    
    private PlayerControls playerControls;
    private float timeBetweenAttacks;
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
        
        AttackCoolDown();
    }

    private void Update()
    {
        Attack();
    }

    public void NewWeapon(MonoBehaviour newWeapon)
    {
        CurrentActiveWeapon = newWeapon;
        AttackCoolDown(); // To protect from infinite attacking by switching weapon
        timeBetweenAttacks = (CurrentActiveWeapon as IWeapon).GetWeaponInfo().weaponCooldown;
    }

    public void WeaponNull()
    {
        CurrentActiveWeapon = null;
    }

    private void AttackCoolDown()
    {
        isAttacking = true;
        StopAllCoroutines();
        StartCoroutine(TimeBetweenAttacksRoutine());
    }

    private IEnumerator TimeBetweenAttacksRoutine()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        isAttacking = false;
    }

    private void StartAttacking() {
        attackButtonDown = true;
    }

    private void StopAttacking() {
        attackButtonDown = false;
    }

    private void Attack()
    {
        if (attackButtonDown && !isAttacking && CurrentActiveWeapon)
        {
            AttackCoolDown();
        
            // Call the Attack() function from the correct class through the IWeapon interface
            (CurrentActiveWeapon as IWeapon).Attack();
        }
        
    }

}
