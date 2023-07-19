using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    public void Attack()
    {
        Debug.Log("Attacking with Staff");
        ActiveWeapon.Instance.ToggleIsAttacking(false);
    }
}
