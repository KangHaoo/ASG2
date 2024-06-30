/// <author>Kang Hao</author>
/// <date>2024-06-24</date>
/// <summary>
/// Handles the player's ability to pick up objective items.
/// </summary>


/// <remarks>
/// This script should be attached to an objective item GameObject.
/// The player needs to have the "Player" tag assigned.
/// </remarks>
/// <example>
/// Attach this script to an objective item GameObject. 
/// Ensure the player GameObject has the "Player" tag.
/// </example>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickupObjective : MonoBehaviour
{
    /// <summary>
    /// Indicates whether the player is within range to pick up the item.
    /// </summary>
    private bool isPlayerInRange = false;

    /// <summary>
    /// Called when another collider enters the trigger collider attached to the object where this script is attached.
    /// Sets <see cref="isPlayerInRange"/> to true if the player enters the trigger.
    /// </summary>
    /// <param name="other">The other collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    /// <summary>
    /// Called when another collider exits the trigger collider attached to the object where this script is attached.
    /// Sets <see cref="isPlayerInRange"/> to false if the player exits the trigger.
    /// </summary>
    /// <param name="other">The other collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    /// <summary>
    /// Called every frame. Checks if the player is in range and presses the F key to pick up the item.
    /// Calls <see cref="GameManager.ObjectiveItemPickedUp"/> and destroys the item.
    /// </summary>
    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            GameManager.instance.ObjectiveItemPickedUp();
            Destroy(gameObject);
        }
    }
}
