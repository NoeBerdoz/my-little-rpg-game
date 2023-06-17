using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake() {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update() {
        // Remove death particles on its end animation
        if (ps && !ps.IsAlive()) {
            DestroySelf();
        }
    }

    public void DestroySelf() {
        Destroy(gameObject);
    }
}
