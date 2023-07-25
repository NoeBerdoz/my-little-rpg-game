using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform arrowSpwanPoint;

    private Animator myAnimator;

    // Peroformance optimisation
    private readonly int FIRE_HASH = Animator.StringToHash("Fire");
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void Attack()
    {
        // Trigger parameter "Fire" is set on Idle animation parameters
        myAnimator.SetTrigger(FIRE_HASH);
        GameObject newArrow =
            Instantiate(arrowPrefab, arrowSpwanPoint.position, ActiveWeapon.Instance.transform.rotation);
        newArrow.GetComponent<Projectile>().UpdateProjectileRange(weaponInfo.weaponRange);
    }
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
    
}
