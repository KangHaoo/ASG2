using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <author>Kang Hao</author>
/// <date>2024-06-24</date>
/// <summary>
/// Handles the level transition by triggering a fade-out animation and loading the next level.
/// </summary>
public class LevelChanger : MonoBehaviour
{
    /// <summary>
    /// Reference to the Animator component controlling the fade animation.
    /// </summary>
    public Animator animator;

    /// <summary>
    /// The index of the level to load after the fade-out animation.
    /// </summary>
    public int levelToLoad;

    /// <summary>
    /// Detects mouse click to trigger the fade-out animation.
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeToLevel(1);
        }
    }

    /// <summary>
    /// Triggers the fade-out animation.
    /// </summary>
    /// <param name="LevelIndex">The index of the level to load.</param>
    public void FadeToLevel(int LevelIndex)
    {
        animator.SetTrigger("Fadeout");
    }

    /// <summary>
    /// Loads the specified level once the fade-out animation is complete.
    /// </summary>
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
