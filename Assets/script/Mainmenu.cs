using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <author>Kang Hao</author>
/// <date>2024-06-21</date>
/// <summary>
/// Handles main menu functionality such as starting the game and quitting the application.
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the next scene in the build order to start the game.
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
