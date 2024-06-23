using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlide;
    public float maxHealth = 100f;
    private float lerpSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {


        if (healthSlider.value != easeHealthSlide.value)
        {
            easeHealthSlide.value = Mathf.Lerp(easeHealthSlide.value, healthSlider.value, lerpSpeed);
        }
    }




    public void SetMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        easeHealthSlide.maxValue = health;
        easeHealthSlide.value = health;
    }

    public void SetHealth(float health)
    {
        healthSlider.value = health;
    }
}