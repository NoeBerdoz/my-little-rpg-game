using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : Singleton<ActiveInventory>
{
    private int activeSlotIndexNum = 0;

    private PlayerControls playerControls;

    protected override void Awake()
    {
        base.Awake();
        
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        playerControls.Inventory.Keyboard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
        
        // Set the sword as default start weapon
        ToggleActiveHighlight(0);
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    public void EquipStartingWeapon()
    {
        // Give sword when player spawns
        ToggleActiveHighlight(0);
    }

    private void ToggleActiveSlot(int numValue)
    {
        ToggleActiveHighlight(numValue - 1);
    }

    private void ToggleActiveHighlight(int indexNum)
    {
        activeSlotIndexNum = indexNum;

        foreach (Transform inventorySlot in this.transform)
        {
            // Set not selected Active Highlight scene object to False
            inventorySlot.GetChild(0).gameObject.SetActive(false);
        }
        
        // Set selected Active Highlight scene object to True
        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
        
        ChangeActiveWeapon();
    }

    private void ChangeActiveWeapon()
    {
        // Disable change on player's death
        if (PlayerHealth.Instance.IsDead)
        {
            return;
        }
        
        // Remove current weapon object before setting new one
        if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
        {
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
        }
        
        Transform childTransform = transform.GetChild(activeSlotIndexNum);
        InventorySlot inventorySlot = childTransform.GetComponentInChildren<InventorySlot>();
        WeaponInfo weaponInfo = inventorySlot.GetWeaponInfo();
        
        // Escape null inventory
        if (weaponInfo == null)
        {
            ActiveWeapon.Instance.WeaponNull();
            return;
        }
        
        GameObject weaponToSpawn = weaponInfo.weaponPrefab;

        GameObject newWeapon =
            Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform.position, Quaternion.identity);
        
        // Reset rotation to 0 to get rid of weapon position bugs when switching
        ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, 0);
        
        // Set new weapon object
        newWeapon.transform.parent = ActiveWeapon.Instance.transform;
        ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
    }
    
}
