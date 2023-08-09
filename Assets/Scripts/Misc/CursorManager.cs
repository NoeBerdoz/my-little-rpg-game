using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        // Set OS cursor invisible
        Cursor.visible = false;

        if (Application.isPlaying) // When Editor is playing
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // Limit custom cursor to inside Game view in prod
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    private void Update()
    {
        Vector2 cursorPos = Input.mousePosition;
        image.rectTransform.position = cursorPos;

    }
}
