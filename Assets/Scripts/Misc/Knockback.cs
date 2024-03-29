using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{

    // Check to see if element is getting knocked back
    public bool GettingKnockedBack { get; private set; }

    [SerializeField] private float knockBackTime = .2f; 

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetKnockedBack(Transform damageSource, float knockBackThrust) {
        GettingKnockedBack = true;
        Vector2 difference = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRoutine());
    }

    private IEnumerator KnockRoutine() {
        // Knockback effect time
        yield return new WaitForSeconds(knockBackTime);

        // Stop Knockback effect
        rb.velocity = Vector2.zero; 
        GettingKnockedBack = false;
    }

}