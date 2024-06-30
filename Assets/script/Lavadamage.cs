/// <author>Kang Hao</author>
/// <date>2024-06-28</date>
/// <summary>
/// Applies damage to the player over time when they stay within a trigger area.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    /// <summary>
    /// Damage per second applied to the player while inside the trigger area.
    /// </summary>
    public float damagePerSecond = 10f;

    /// <summary>
    /// Applies damage to the player over time while they stay within the trigger area.
    /// </summary>
    /// <param name="other">The Collider of the object entering the trigger area.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damagePerSecond * Time.deltaTime); // Apply damage over time based on delta time
            }
        }
    }
}
