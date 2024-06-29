using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    // Define a bool to check if the key is collected
    private bool isCollected = false;

    private void Update()
    {
        // Check if the player presses 'F' to collect the key
        if (!isCollected && Input.GetKeyDown(KeyCode.F))
        {
            CollectKey();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            CollectKey();
        }
    }

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
