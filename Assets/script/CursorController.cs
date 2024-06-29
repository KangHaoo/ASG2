using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    void Start()
    {
        ShowCursor();
    }

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

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Make the cursor invisible
    }
}

