using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjective : MonoBehaviour
{
    private bool isPlayerInRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            GameManager.instance.ObjectiveItemPickedUp();
            Destroy(gameObject);
        }
    }
}
