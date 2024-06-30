/// <author>Kang Hao</author>
/// <date>2024-06-24</date>
/// /// <summary>
/// Handles the opening of a door when the player interacts with it.
/// </summary>


/// <remarks>
/// This script should be attached to a GameObject that controls the door.
/// The door GameObject should be assigned in the inspector.
/// </remarks>
/// <example>
/// Attach this script to a GameObject, assign the door GameObject in the inspector.
/// The player can open the door by pressing the 'F' key after the door is enabled.
/// </example>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DoorOpener : MonoBehaviour
{
    /// <summary>
    /// The door GameObject that will be opened.
    /// </summary>
    public GameObject door;

    /// <summary>
    /// Indicates whether the door is open.
    /// </summary>
    private bool isOpen = false;

    /// <summary>
    /// Indicates whether the door has been opened.
    /// </summary>
    private bool hasBeenOpened = false;

    /// <summary>
    /// The rotation of the door when it is closed.
    /// </summary>
    private Quaternion closedRotation;

    /// <summary>
    /// The rotation of the door when it is open.
    /// </summary>
    private Quaternion openRotation;

    /// <summary>
    /// Initializes the closed and open rotations of the door.
    /// </summary>
    private void Start()
    {
        // Initialize closed and open rotations
        closedRotation = door.transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, 90, 0); // Adjust the angle for your door's open position
    }

    /// <summary>
    /// Enables the door to be opened.
    /// </summary>
    public void EnableDoor()
    {
        isOpen = true;
    }

    /// <summary>
    /// Called every frame. Checks if the player presses the 'F' key to open the door.
    /// </summary>
    private void Update()
    {
        // Check if the player presses 'F' to open the door
        if (isOpen && !hasBeenOpened && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(OpenDoorAnimation());
            hasBeenOpened = true; // Mark the door as opened
        }
    }

    /// <summary>
    /// Coroutine to animate the door opening.
    /// </summary>
    private IEnumerator OpenDoorAnimation()
    {
        float duration = 1.0f; // Adjust the duration of the animation
        float timer = 0.0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = Mathf.Clamp01(timer / duration);

            // Interpolate rotation from closedRotation to openRotation
            door.transform.rotation = Quaternion.Slerp(closedRotation, openRotation, t);

            yield return null;
        }
    }
}
