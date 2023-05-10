using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private PlayerControls playerControls;
    private Animator myAnimator;

    private void Awake() {
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

    private void Attack() {
        myAnimator.SetTrigger("Attack");
    }

}
