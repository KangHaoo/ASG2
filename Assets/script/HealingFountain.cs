/// <author>Kang Hao</author>
/// <date>2024-06-26</date>
/// <summary>
/// Provides healing functionality to the player when they interact with it.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HealingFountain : MonoBehaviour
{
    /// <summary>
    /// Amount of health restored to the player.
    /// </summary>
    public int healAmount = 20;

    /// <summary>
    /// Cooldown period between consecutive healing actions (in seconds).
    /// </summary>
    public float cooldown = 5f;

    /// <summary>
    /// Audio clip played when healing occurs.
    /// </summary>
    public AudioClip healingSound;

    private bool canHeal = true;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject.");
        }
    }

    /// <summary>
    /// Called when a collider stays triggered with this object.
    /// </summary>
    /// <param name="other">The collider that stays triggered.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && canHeal)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                HealPlayer(other.gameObject);
                canHeal = false;
                Invoke("ResetCooldown", cooldown); // Reset cooldown after 'cooldown' seconds
            }
        }
    }

    /// <summary>
    /// Restores health to the player.
    /// </summary>
    /// <param name="player">The player GameObject to heal.</param>
    private void HealPlayer(GameObject player)
    {
        // Example: Assuming player has a Health component or similar
        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.Heal(healAmount); // Adjust this based on your player health management
            PlayHealingSound();
        }
    }

    /// <summary>
    /// Resets the cooldown timer to allow healing again.
    /// </summary>
    private void ResetCooldown()
    {
        canHeal = true;
    }

    /// <summary>
    /// Plays the healing sound effect.
    /// </summary>
    private void PlayHealingSound()
    {
        if (audioSource != null && healingSound != null)
        {
            audioSource.PlayOneShot(healingSound);
        }
    }
}
