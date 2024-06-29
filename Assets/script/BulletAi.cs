using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAI : MonoBehaviour
{
    public int damage = 10; // Damage value of the bullet
    public GameObject impactEffect; // Effect to play when bullet hits something
    public float lifespan = 5f; // lifespan of the bullet in seconds

    private void Start()
    {
        // Destroy the bullet after 'lifespan' seconds
        Destroy(gameObject, lifespan);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug message to check collision
        Debug.Log("Bullet collided with: " + collision.gameObject.name);

        // Check if the collision object is in the Player layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Check if the collision object has the PlayerHealth component
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();

            if (health != null)
            {
                // Call the takeDamage method of PlayerHealth
                health.TakeDamage(damage);

                // Debug message to confirm damage was applied
                Debug.Log("Bullet hit player, applied damage: " + damage);

                // Optionally, instantiate an impact effect at the collision point
                if (impactEffect != null)
                {
                    Instantiate(impactEffect, transform.position, Quaternion.identity);
                }

                // Destroy the bullet immediately on collision
                Destroy(gameObject);
            }
        }
        else
        {
            // Optionally, handle collisions with other objects
            if (impactEffect != null)
            {
                Instantiate(impactEffect, transform.position, Quaternion.identity);
            }

            // Destroy the bullet immediately on collision with other objects
            Destroy(gameObject);
        }
    }
}
