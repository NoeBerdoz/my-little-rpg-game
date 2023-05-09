using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;

    private Vector2 moveDirection;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime)); // fixedDeltaTime for framerates independance
    }

    public void MoveTo(Vector2 targetPosition) {
        moveDirection = targetPosition;
    }
}
