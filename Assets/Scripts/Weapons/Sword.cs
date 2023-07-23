using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject slashAnimPrefab;
    [SerializeField] private Transform slashAnimSpawnPoint;
    [SerializeField] private WeaponInfo weaponInfo;

    private Transform weaponCollider;
    private Animator myAnimator;
    private GameObject slashAnim;


    private void Awake() {
        myAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        weaponCollider = PlayerController.Instance.GetWeaponCollider();
        
        // this is bad, but here for learning what to not do
        slashAnimSpawnPoint = GameObject.Find("SlashAnimSpawnPoint").transform;
    }

    private void Update() {
        MouseFollowWithOffset();
    }

    public WeaponInfo GetWeaponInfo()
    {
        return weaponInfo;
    }

    public void Attack() {
        myAnimator.SetTrigger("Attack");
        weaponCollider.gameObject.SetActive(true);

        slashAnim = Instantiate(slashAnimPrefab, slashAnimSpawnPoint.position, Quaternion.identity); // Quaternion to gives the same rotation as the prefab
        // Set parent as active weapon in hierarchy
        slashAnim.transform.parent = this.transform.parent;
    }

    public void DoneAttackingAnimEvent() {
        // Deactivate collider
        weaponCollider.gameObject.SetActive(false);
    }

    public void SwingUpFlipAnimEvent() {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(-180, 0, 0);

        if (PlayerController.Instance.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    public void SwingDownFlipAnimEvent() {
        slashAnim.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        if (PlayerController.Instance.FacingLeft) {
            slashAnim.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    // Make the sword flip horizontally depending on player position
    private void MouseFollowWithOffset() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position); 

        // Gives a number between 0 and 6.x as it is as radian and converts it to degrees
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg; 

        if (mousePos.x < playerScreenPoint.x) {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle); // Rotation on Euler angle principle
            weaponCollider.transform.rotation = Quaternion.Euler(0, -180, 0);
        } else {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle); // Rotation on Euler angle principle
            weaponCollider.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
