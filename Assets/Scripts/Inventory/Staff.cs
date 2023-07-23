using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponInfo weaponInfo;
    [SerializeField] private GameObject magicLaser;
    [SerializeField] private Transform magicLaserSpawnPoint;

    private Animator myAnimator;
    readonly int AttackHash = Animator.StringToHash("Attack");


    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }
  
    public void Attack()
    {
        // Trigger parameter "Laser" is set on Idle animation parameters
        myAnimator.SetTrigger(AttackHash);

    }

    private void SpawnStaffProjectileAnimEvent()
    {
        GameObject newLaser =
            Instantiate(magicLaser, magicLaserSpawnPoint.position, Quaternion.identity);
        // newLaser.GetComponent<Projectile>().UpdateWeaponInfo(weaponInfo);
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    private void Update()
    {
        MouseFollowWithOffset();
    }


    // Make the staff flip horizontally depending on player position
    private void MouseFollowWithOffset() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position); 

        // Gives a number between 0 and 6.x as it is as radian and converts it to degrees
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; 

        if (mousePos.x < playerScreenPoint.x) {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle); // Rotation on Euler angle principle
        } else {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle); // Rotation on Euler angle principle
        }
    }
}
