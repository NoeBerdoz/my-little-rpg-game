using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
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
        // Kill game object when health is down
        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
