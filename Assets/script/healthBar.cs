/// <author>Kang Hao</author>
/// <date>2024-06-24</date>
/// <summary>
/// Manages the health bar UI for displaying and updating player health.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class healthBar : MonoBehaviour
{
    /// <summary>
    /// Slider component representing the current health.
    /// </summary>
    public Slider healthSlider;

    /// <summary>
    /// Slider used for smooth easing of health transitions.
    /// </summary>
    public Slider easeHealthSlide;

    /// <summary>
    /// Maximum health value the health bar can display.
    /// </summary>
    public float maxHealth = 100f;

    /// <summary>
    /// Speed of the smooth easing transition between health values.
    /// </summary>
    private float lerpSpeed = 0.05f;

    /// <summary>
    /// Initializes the health bar with maximum health values.
    /// </summary>
    void Start()
    {
        SetMaxHealth(maxHealth);
    }

    /// <summary>
    /// Updates the health bar each frame to smoothly transition between current and eased health values.
    /// </summary>
    void Update()
    {
        if (healthSlider.value != easeHealthSlide.value)
        {
            easeHealthSlide.value = Mathf.Lerp(easeHealthSlide.value, healthSlider.value, lerpSpeed);
        }
    }

    /// <summary>
    /// Sets the maximum health value for both health sliders.
    /// </summary>
    /// <param name="health">The maximum health value to set.</param>
    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        easeHealthSlide.maxValue = health;
        easeHealthSlide.value = health;
    }

    /// <summary>
    /// Sets the current health value of the health slider.
    /// </summary>
    /// <param name="health">The current health value to set.</param>
    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}
