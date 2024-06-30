/// <author>Kang Hao</author>
/// <date>2024-06-29</date>
/// <summary>
/// Loads the player's position data from PlayerPrefs and applies it to the player GameObject.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerDataLoader : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject

    /// <summary>
    /// Checks PlayerPrefs for saved player position data and moves the player GameObject to that position.
    /// </summary>
    void Start()
    {
        // Check if PlayerPrefs contains player position data
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            // Retrieve saved player position
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");

            // Set the player's position to the saved coordinates
            player.transform.position = new Vector3(x, y, z);
        }
    }
}

// PlayerPrefs is useful for storing simple data, but for more complex data or larger amounts of data,
// consider using other serialization methods or data storage solutions.
