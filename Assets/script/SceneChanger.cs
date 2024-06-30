/// <author>Kang Hao</author>
/// <date>2024-06-27</date>
/// <summary>
/// Controls scene transitions with fade-out animation triggered by player entering a trigger zone.
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour
{
    public int targetScene; // The index of the scene to transition to
    public Animator animator; // The animator component controlling the fade-out animation

    void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the trigger zone
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            FadeToLevel(targetScene); // Initiate scene transition
        }
    }

    /// <summary>
    /// Initiates the scene transition to the specified level index with a fade-out animation.
    /// </summary>
    /// <param name="levelIndex">The index of the scene to transition to.</param>
    public void FadeToLevel(int levelIndex)
    {
        Debug.Log("Fade to level: " + levelIndex);
        targetScene = levelIndex; // Set the target scene index
        animator.SetTrigger("FadeOut"); // Trigger the fade-out animation
    }

    /// <summary>
    /// Callback function called when the fade-out animation completes. Loads the target scene.
    /// </summary>
    public void OnFadeComplete()
    {
        Debug.Log("Fade complete, loading scene: " + targetScene);
        SceneManager.LoadScene(targetScene); // Load the target scene
    }
}

