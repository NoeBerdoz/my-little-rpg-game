using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Knockback knockback;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        // Don't move position on knocked back
        if (knockback.GettingKnockedBack) { return; }
        
        rb.MovePosition(rb.position + moveDirection * (moveSpeed * Time.fixedDeltaTime)); // fixedDeltaTime for framerates independance

        if (moveDirection.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    public void MoveTo(Vector2 targetPosition) {
        moveDirection = targetPosition;
    }
}
