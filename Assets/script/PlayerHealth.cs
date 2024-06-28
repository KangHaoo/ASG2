using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100f;
    public float health;
    private float lerpSpeed = 0.05f;

    void Start()
    {
        health = maxHealth;
        healthSlider.value = health;
        easeHealthSlider.value = health;
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
            Destroy(gameObject); // Destroy the player object when health reaches zero
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        Debug.Log("Player took damage: " + damage + ", current health: " + health);
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Player destroyed");
        }
    }
    public void Heal(float healAmount)
    {
        health += healAmount;
        health = Mathf.Min(health, maxHealth); //ensure that the health dont exceed maxhealth


    }
}
