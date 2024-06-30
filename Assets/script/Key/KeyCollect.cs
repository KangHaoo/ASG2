/// <author>Kang Hao</author>
/// <date>2024-06-23</date>
/// <summary>
/// Handles the collection of keys by the player.
/// </summary>


/// <remarks>
/// This script should be attached to a key GameObject.
/// The player needs to have the "Player" tag assigned.
/// </remarks>
/// <example>
/// Attach this script to a key GameObject. 
/// Ensure the player GameObject has the "Player" tag.
/// The player can collect the key by pressing the 'C' key or by entering the trigger.
/// </example>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyCollect : MonoBehaviour
{
    /// <summary>
    /// Indicates whether the key has been collected.
    /// </summary>
    private bool isCollected = false;

    /// <summary>
    /// Called every frame. Checks if the player presses the 'C' key to collect the key.
    /// </summary>
    private void Update()
    {
        // Check if the player presses 'C' to collect the key
        if (!isCollected && Input.GetKeyDown(KeyCode.C))
        {
            CollectKey();
        }
    }

    /// <summary>
    /// Called when another collider enters the trigger collider attached to the object where this script is attached.
    /// Collects the key if the player enters the trigger.
    /// </summary>
    /// <param name="other">The other collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            CollectKey();
        }
    }

    /// <summary>
    /// Collects the key and enables the door interaction.
    /// </summary>
    private void CollectKey()
    {
        isCollected = true;
        // Add your key collection logic here (e.g., disable the key GameObject)
        gameObject.SetActive(false);

        // Call the method to open the door
        DoorOpener doorOpener = FindObjectOfType<DoorOpener>();
        if (doorOpener != null)
        {
            doorOpener.EnableDoor(); // Enable the door interaction
        }
    }
}
