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
