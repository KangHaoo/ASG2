using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject door;
    public int keysNeeded = 3;
    private int keysCollected = 0;

    public void CollectKey()
    {
        keysCollected++;
        UpdateDoorState();
    }

    private void UpdateDoorState()
    {
        if (keysCollected >= keysNeeded)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        // Implement sliding door logic here
        // Example: Move the door to the open position
        door.transform.Translate(Vector3.right * 2.0f); // Adjust as per your door's movement requirements
    }
}
