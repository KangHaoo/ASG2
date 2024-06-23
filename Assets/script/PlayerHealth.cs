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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            takeDamage(10);
        }

        if (easeHealthSlider.value != healthSlider.value)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }

        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    void takeDamage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }
}
