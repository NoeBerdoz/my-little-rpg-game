using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;

    private PlayerControls playerControls;
    private Animator myAnimator;
    private PlayerController playerController;
    private ActiveWeapon activeWeapon;

    private GameObject slashAnim;

    private void Awake() {
        playerController = GetComponentInParent<PlayerController>();
        activeWeapon = GetComponentInParent<ActiveWeapon>();
        myAnimator = GetComponent<Animator>();
        playerControls = new PlayerControls();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    void Start()
    {
        // Call Attack function on control input Attack
        playerControls.Combat.Attack.started += _ => Attack(); // '_' synthax to not pass any parameters to the Attack ()
    }

    private void Update() {
        MouseFollowWithOffset(); 
    }

    private void Attack() {
        myAnimator.SetTrigger("Attack");
        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity); // Quaternion to gives the same rotation as the prefab
        // Set parent as active weapon in hierarchy
        slashAnim.transform.parent = this.transform.parent;
    }

    public void SwingUpFlipAnim() {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (playerController.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnim() {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (playerController.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Make the sword flip horizontally depending on player position
    private void MouseFollowWithOffset() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(playerController.transform.position); 

        // Gives a number between 0 and 6.x as it is as radian and converts it to degrees
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; 

        if (mousePos.x < playerScreenPoint.x) {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, angle); // Rotation on Euler angle principle
        } else {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, angle); // Rotation on Euler angle principle
        }
    }

}
