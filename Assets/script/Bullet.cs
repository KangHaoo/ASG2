using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 20; // Damage value of the bullet
    public GameObject impactEffect; // Effect to play when bullet hits something
    public float lifespan = 5f; // lifespan of the bullet in seconds

    private void Start()
    {
        //destroy the bullet after the 'lifespan' seconds
        Destroy(gameObject, lifespan);
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyAiTutorial enemy = collision.gameObject.GetComponent<EnemyAiTutorial>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Call the TakeDamage method of EnemyAiTutorial
        }

        // Optionally, instantiate an impact effect at the collision point
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        // Destroy the bullet immediately on collision
        Destroy(gameObject);
    }
}
