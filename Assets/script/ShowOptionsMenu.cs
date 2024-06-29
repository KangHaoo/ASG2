using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu; // Assign the options panel in the Inspector
    private bool isPaused = false;

    private void Update()
    {
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

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        optionsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        optionsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
