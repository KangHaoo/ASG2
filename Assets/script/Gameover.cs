using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene(0); // Replace "MainMenu" with the name of your main menu scene
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops the editor from playing when testing in the Unity Editor
        #endif
    }
}

