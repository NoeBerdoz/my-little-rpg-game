using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Set private value from public call
    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }
    public static PlayerController Instance;

    [SerializeField] private float moveSpeed = 1f;

    private PlayerControls playerControls;
    // Store values incoming from player inputs 
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;

    private bool facingLeft = false;

    private void Awake() {
        Instance = this;
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
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
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput() {
        // Getting players controls from action map 'Player Controls' 
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime)); // fixedDeltaTime for framerates independance
    }

    private void AdjustPlayerFacingDirection() {

        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position); // transform is the built-in component information

        if (mousePosition.x < playerScreenPoint.x) {
            mySpriteRender.flipX = true;
            FacingLeft = true;
        } else {
            mySpriteRender.flipX = false;
            FacingLeft = false;
        }

    }

}

