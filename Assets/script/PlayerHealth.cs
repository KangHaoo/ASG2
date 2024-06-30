
/// <author>Kang Hao</author>
/// <date>2024-06-22</date>
/// <summary>
/// Manages the player's health, updates health sliders, handles damage, and healing.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider; // Slider displaying current health
    public Slider easeHealthSlider; // Easing slider for smooth health transitions
    public float maxHealth = 100f; // Maximum health value
    private float health; // Current health value
    private float lerpSpeed = 0.05f; // Speed of health slider interpolation
    private static bool isInitialized = false; // Flag to ensure initialization only once

    /// <summary>
    /// Initializes the player's health based on saved data or default maxHealth.
    /// </summary>
    void Start()
    {
        if (!isInitialized)
        {
            if (GameManager.instance != null)
            {
                health = GameManager.instance.LoadPlayerHealth();
            }
            else
            {
                health = maxHealth;
            }

            healthSlider.value = health;
            easeHealthSlider.value = health;
            isInitialized = true;
        }
        else
        {
            // Prevent re-initialization of health values
            health = GameManager.instance.LoadPlayerHealth();
        }
    }

    /// <summary>
    /// Updates health sliders and handles player death when health drops to zero.
    /// </summary>
    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }

        if (easeHealthSlider.value != healthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene(4); // Replace with the appropriate game over scene index or logic

            // Implement your logic for player death or reset
        }
    }

    /// <summary>
    /// Applies damage to the player's health and handles health updates and saving.
    /// </summary>
    /// <param name="damage">Amount of damage to apply to the player.</param>
    public void TakeDamage(float damage)
    {
        float previousHealth = health;
        health -= damage;
        Debug.Log("Player took damage: " + damage + ", current health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the player object on death
            SceneManager.LoadScene(4); // Replace with the appropriate game over scene index or logic
        }

        // Save health only if it has changed
        if (health != previousHealth && GameManager.instance != null)
        {
            GameManager.instance.SavePlayerHealth(health);
        }
    }

    /// <summary>
    /// Restores health to the player and handles health updates and saving.
    /// </summary>
    /// <param name="healAmount">Amount of health to restore to the player.</param>
    public void Heal(float healAmount)
    {
        float previousHealth = health;
        health += healAmount;
        health = Mathf.Min(health, maxHealth); // Ensure that the health doesn't exceed maxHealth

        // Save health only if it has changed
        if (health != previousHealth && GameManager.instance != null)
        {
            GameManager.instance.SavePlayerHealth(health);
        }
    }

    // No need for OnDestroy method since player object persists
}
