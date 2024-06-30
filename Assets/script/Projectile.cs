/// <author>Kang Hao</author>
/// <date>2024-06-26</date>
/// <summary>
/// Controls the behavior of a projectile fired by the player.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Projectile : MonoBehaviour
{
    public float speed = 20f; // Speed of the projectile
    public int damage = 10; // Damage inflicted on enemies
    public Rigidbody rb; // Rigidbody component of the projectile

    void Start()
    {
        rb.velocity = transform.forward * speed; // Set the initial velocity of the projectile
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyAiTutorial enemy = other.GetComponent<EnemyAiTutorial>(); // Attempt to get the EnemyAiTutorial component from the collided object
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Damage the enemy if it has an EnemyAiTutorial component
            Destroy(gameObject); // Destroy the bullet on impact
        }
        else
        {
            Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds if it doesn't hit an enemy
        }
    }
}
