using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float accelerationRate = 2f;
    [SerializeField] private float moveSpeed = 3f;
    
    
    private Vector3 moveDirection;
    private Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 playerPos = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPos) < pickUpDistance)
        {
            moveDirection = (playerPos - transform.position).normalized; // normalized set only Vector direction
            moveSpeed += accelerationRate;

        }
        else
        {
            moveDirection = Vector3.zero;
            moveSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Destroy(gameObject);
        }
    }
}
