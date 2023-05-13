using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyHealth : MonoBehaviour
{
    [SerializeField] private int startingHealth = 3;

    private int currentHealth;

    private void Start() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        DetectDeath();    
    }

    public void DetectDeath() {
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
