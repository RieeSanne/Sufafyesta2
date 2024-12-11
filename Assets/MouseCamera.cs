using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float sensitivity = 2f; // Sensitivity for mouse movement
    private Vector2 rotation = Vector2.zero; // Tracks horizontal and vertical rotation

    void Start()
    {
        // Lock the cursor to the center of the screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Hide the cursor
    }

    void Update()
    {
        // Toggle cursor lock mode when LeftAlt is pressed
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true; // Show the cursor
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false; // Hide the cursor
            }
        }

        // Only process mouse input when the cursor is locked
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            // Get mouse input
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;

            // Adjust rotation based on mouse input
            rotation.x += mouseX; // Horizontal rotation

            transform.localRotation = Quaternion.Euler(rotation.y, rotation.x, 0f);
        }
    }
}
