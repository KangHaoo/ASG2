/// <author>Kang Hao</author>
/// <date>2024-06-26</date>
/// /// <summary>
/// Manages the behavior of the bullet, including its lifespan, collision detection, and damage application.
/// </summary>


/// <remarks>
/// This script should be attached to the bullet GameObject.
/// The bullet will be destroyed after its lifespan or upon collision.
/// </remarks>
/// <example>
/// Attach this script to a bullet GameObject.
/// Ensure that the bullet has a Rigidbody and a Collider component.
/// </example>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Bullet : MonoBehaviour
{
    /// <summary>
    /// The damage value of the bullet.
    /// </summary>
    public int damage = 20;

    /// <summary>
    /// The effect to play when the bullet hits something.
    /// </summary>
    public GameObject impactEffect;

    /// <summary>
    /// The lifespan of the bullet in seconds.
    /// </summary>
    public float lifespan = 5f;

    /// <summary>
    /// Called on the frame when a script is enabled just before any of the Update methods are called the first time.
    /// Destroys the bullet after its lifespan.
    /// </summary>
    private void Start()
    {
        // Destroy the bullet after the 'lifespan' seconds
        Destroy(gameObject, lifespan);
    }

    /// <summary>
    /// Called when this collider/rigidbody has begun touching another rigidbody/collider.
    /// Applies damage to the enemy if the bullet hits one, plays an impact effect, and destroys the bullet.
    /// </summary>
    /// <param name="collision">The Collision data associated with this collision event.</param>
    private void OnCollisionEnter(Collision collision)
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
