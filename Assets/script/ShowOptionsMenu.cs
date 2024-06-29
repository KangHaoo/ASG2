using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowOptionsMenu : MonoBehaviour
{
    public GameObject optionsMenu; // Assign the options panel in the Inspector

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (optionsMenu.activeSelf)
            {
                // Resume the game
                Time.timeScale = 1f;
                optionsMenu.SetActive(false);
            }
            else
            {
                // Pause the game
                Time.timeScale = 0f;
                optionsMenu.SetActive(true);
            }
        }
    }
}
