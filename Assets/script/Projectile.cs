using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody rb;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyAiTutorial enemy = other.GetComponent<EnemyAiTutorial>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject); // Destroy the bullet on impact
        }
        else
        {
            Destroy(gameObject, 2f); // Destroy the bullet after 2 seconds if it doesn't hit an enemy
        }
    }
}