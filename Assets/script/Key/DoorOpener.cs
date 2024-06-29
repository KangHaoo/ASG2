using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    // Add a reference to the door GameObject in the Inspector
    public GameObject door;

    // Define a bool to check if the door is open
    private bool isOpen = false;
    private bool hasBeenOpened = false; // Track if the door has been opened

    // Rotation angles for the door's closed and open positions
    private Quaternion closedRotation;
    private Quaternion openRotation;

    private void Start()
    {
        // Initialize closed and open rotations
        closedRotation = door.transform.rotation;
        openRotation = closedRotation * Quaternion.Euler(0, 90, 0); // Adjust the angle for your door's open position
    }

    // Enable door interaction after key collection
    public void EnableDoor()
    {
        isOpen = true;
    }

    private void Update()
    {
        // Check if the player presses 'F' to open the door
        if (isOpen && !hasBeenOpened && Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(OpenDoorAnimation());
            hasBeenOpened = true; // Mark the door as opened
        }
    }

    // Coroutine to animate the door opening
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
