using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : MonoBehaviour
{
    public int healAmount = 20; // Amount of health restored
    public float cooldown = 5f; // Cooldown between healing (in seconds)

    private bool canHeal = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canHeal)
        {
            HealPlayer(other.gameObject);
            canHeal = false;
            Invoke("ResetCooldown", cooldown); // Reset cooldown after 'cooldown' seconds
        }
    }

    private void HealPlayer(GameObject player)
    {
        // Example: Assuming player has a Health component or similar
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.Heal(healAmount); // Adjust this based on your player health management
        }
    }

    private void ResetCooldown()
    {
        canHeal = true;
    }
}
