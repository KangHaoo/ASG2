using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    private float health;
    private float lerpSpeed = 0.05f;
    private static bool isInitialized = false;

    /*void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }*/

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
            // Implement your logic for player death or reset
        }
    }

    public void TakeDamage(float damage)
    {
        float previousHealth = health;
        health -= damage;
        Debug.Log("Player took damage: " + damage + ", current health: " + health);

        if (health <= 0)
        {
            // Implement your logic for player death or reset
        }

        // Save health only if it has changed
        if (health != previousHealth && GameManager.instance != null)
        {
            GameManager.instance.SavePlayerHealth(health);
        }
    }

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


