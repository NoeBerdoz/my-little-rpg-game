using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TransparentDetection : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float transparencyAmount = 0.8f;
    [SerializeField] private float fadeTime = .4f;

    private Renderer rendererComponent;
    
    private void Awake()
    {
        rendererComponent = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerController>()) { 
            // Fade object
            StartCoroutine(FadeRoutine(rendererComponent, fadeTime, rendererComponent.material.color.a, transparencyAmount));
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerController>()) { 
            // Unfade object
            StartCoroutine(FadeRoutine(rendererComponent, fadeTime, rendererComponent.material.color.a, 1f));
        }
    }

    private IEnumerator FadeRoutine(Renderer rendererValue, float fadeTimeValue, float startValue, float targetTransparency) {
        float elapsedTime = 0;
        while (elapsedTime < fadeTimeValue)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapsedTime / fadeTimeValue);
            rendererValue.material.color = new Color(rendererValue.material.color.r, rendererValue.material.color.g, rendererValue.material.color.b, newAlpha);
            yield return null;
        }
    }
}
