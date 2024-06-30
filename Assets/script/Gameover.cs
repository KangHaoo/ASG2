using System.Collections;
/// <author>Kang Hao</author>
/// <date>2024-06-29</date>
/// <summary>
/// Manages game over functionality, including returning to the main menu and quitting the game.
/// </summary>

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Gameover : MonoBehaviour
{
    /// <summary>
    /// Loads the main menu scene.
    /// </summary>
    public void Back()
    {
        SceneManager.LoadScene(0); // Replace "MainMenu" with the name or index of your main menu scene
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops the editor from playing when testing in the Unity Editor
#endif
    }
}
