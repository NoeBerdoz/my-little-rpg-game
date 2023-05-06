using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    // Store values incoming from player inputs 
    private Vector2 movement;
    private Rigidbody2D rb;

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    // Handle Player input
    private void Update() {
        PlayerInput();
    }

    // Handle Physics
    private void FixedUpdate() {
        Move();
    }

    private void PlayerInput() {
        // Getting players controls from action map 'Player Controls' 
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        Debug.Log(movement.x);
    }

    private void Move() {
        Debug.Log("hello");
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime)); // fixedDeltaTime for framerates independance
    }

}

