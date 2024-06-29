using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjective : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.ObjectiveItemPickedUp();
            Destroy(gameObject);
        }
    }
}
