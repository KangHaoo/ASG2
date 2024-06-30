/// <author>Kang Hao</author>
/// <date>2024-06-25</date>
/// <summary>
/// Controls the display of the menu based on game events and player input.
/// </summary>



/// <remarks>
/// This script should be attached to a GameObject in the scene.
/// The menu GameObject should be assigned in the inspector.
/// </remarks>
/// <example>
/// Attach this script to a GameObject and assign the menu GameObject in the inspector.
/// </example>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    /// <summary>
    /// The menu GameObject that will be toggled on and off.
    /// </summary>
    public GameObject menu; // Assign your menu GameObject in the inspector

    /// <summary>
    /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// Ensures the menu is hidden at the start of each scene.
    /// </summary>
    private void Start()
    {
        // Ensure the menu is hidden at the start of each scene
        menu.SetActive(false);
    }

    /// <summary>
    /// Called every frame. Checks if the objective item is picked up and if the player presses the M key.
    /// Toggles the menu accordingly.
    /// </summary>
    private void Update()
    {
        if (GameManager.instance.IsObjectiveItemPickedUp() && Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }

    /// <summary>
    /// Toggles the menu's active state.
    /// </summary>
    private void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
