using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;

    public void Attack()
    {
        Debug.Log("Attacking with Bow");
    }
    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }
    
}
