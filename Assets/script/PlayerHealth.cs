using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float IerpTimer;
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    //public ImageConversion FrontHealthBar;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        ///health - Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(Random.Range(5, 10));
        }

    }
    public void UpdateHealthUI()
    {
        Debug.Log(health);
        //float fiilF = FrontHealthBar.fillAmount;
        //float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;

        ///if(fillB > hFraction)
        {
            //FrontHealthBar.fillAmount = hFraction;
           // backHealthBar.color = Color.red;
            IerpTimer += Time.deltaTime;
           // float percentComplete = IerpTimer / chipSpeed)
        }


    }

    public void TakeDamage(float damage)
    {
        health -= damage;

    }
}
