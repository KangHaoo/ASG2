/// <author>Kang Hao</author>
/// <date>2024-06-30</date>
/// <summary>
/// Manages the visibility and lock state of the cursor.
/// </summary>

/// <remarks>
/// This script should be attached to a GameObject in the scene.
/// It toggles the cursor visibility and lock state when the 'O' key is pressed.
/// </remarks>
/// <example>
/// Attach this script to a GameObject in your scene. 
/// Press the 'O' key to toggle the cursor visibility and lock state.
/// </example>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CursorController : MonoBehaviour
{
    /// <summary>
    /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// Shows the cursor at the start.
    /// </summary>
    void Start()
    {
        ShowCursor();
    }

    /// <summary>
    /// Called every frame. Toggles the cursor visibility and lock state when the 'O' key is pressed.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (Cursor.visible)
            {
                HideCursor();
            }
            else
            {
                ShowCursor();
            }
        }
    }

    /// <summary>
    /// Shows the cursor and unlocks it.
    /// </summary>
    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    /// <summary>
    /// Hides the cursor and locks it.
    /// </summary>
    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Make the cursor invisible
    }
}
