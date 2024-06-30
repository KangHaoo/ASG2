/// <author>Kang Hao</author>
/// <date>2024-06-27</date>
/// <summary>
/// Controls the showing and hiding of an options menu panel and game pausing/resuming.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowOptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu; // Assign the options panel in the Inspector
    private bool isPaused = false; // Flag to track if the game is paused

    private void Update()
    {
        // Check for input to toggle options menu and game pause/resume
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (isPaused)
            {
                // Resume the game
                ResumeGame();
            }
            else
            {
                // Pause the game
                PauseGame();
            }
        }
    }

    /// <summary>
    /// Pauses the game and displays the options menu.
    /// </summary>
    void PauseGame()
    {
        isPaused = true; // Set the game to paused state
        Time.timeScale = 0f; // Stop time in the game
        optionsMenu.SetActive(true); // Show the options menu
        Cursor.lockState = CursorLockMode.None; // Unlock cursor to interact with UI
        Cursor.visible = true; // Show cursor
    }

    /// <summary>
    /// Resumes the game and hides the options menu.
    /// </summary>
    void ResumeGame()
    {
        isPaused = false; // Set the game to resumed state
        Time.timeScale = 1f; // Restore normal time flow
        optionsMenu.SetActive(false); // Hide the options menu
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to the center of the screen
        Cursor.visible = false; // Hide cursor
    }
}
