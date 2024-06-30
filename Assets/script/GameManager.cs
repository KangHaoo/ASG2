/// <author>Kang Hao</author>
/// <date>2024-06-22</date>
/// <summary>
/// Manages game-wide settings, player health, and objective status.
/// </summary>

/// <remarks>
/// This script should be attached to a persistent GameObject in the scene.
/// Handles saving and loading player health, weapon state, audio settings, and game quality.
/// </remarks>
/// <example>
/// Attach this script to a GameObject that persists across scenes (e.g., GameManager).
/// Use GameManager.instance to access its methods and properties from other scripts.
/// </example>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/// <summary>
/// Manages game-wide settings, player health, and objective status.
/// </summary>
/// <remarks>
/// This script should be attached to a persistent GameObject in the scene.
/// Handles saving and loading player health, weapon state, audio settings, and game quality.
/// </remarks>
/// <example>
/// Attach this script to a GameObject that persists across scenes (e.g., GameManager).
/// Use GameManager.instance to access its methods and properties from other scripts.
/// </example>

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Static instance of the GameManager, allowing it to be accessed from any script.
    /// </summary>
    public static GameManager instance;

    /// <summary>
    /// Current health of the player.
    /// </summary>
    public float playerHealth = 100f;

    /// <summary>
    /// Name of the current weapon the player is using.
    /// </summary>
    public string currentWeaponName;

    /// <summary>
    /// Volume level of the game audio.
    /// </summary>
    public float audioVolume = 0.75f;

    /// <summary>
    /// Quality level of the game graphics.
    /// </summary>
    public int qualityLevel = 2;

    /// <summary>
    /// Whether the game is running in fullscreen mode.
    /// </summary>
    public bool isFullscreen = true;

    /// <summary>
    /// Flag indicating if the objective item has been picked up.
    /// </summary>
    private bool objectiveItemPickedUp = false;

    void Awake()
    {
        // Singleton pattern to ensure only one GameManager instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scene changes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    void Start()
    {
        if (instance == this)
        {
            Debug.Log("GameManager instance is set correctly.");
            LoadSettings();

            // Apply loaded settings
            AudioMixer audioMixer = FindObjectOfType<SettingsMenu>().audioMixer;
            audioMixer.SetFloat("volume", audioVolume);
            QualitySettings.SetQualityLevel(qualityLevel);
            Screen.fullScreen = isFullscreen;
        }
        else
        {
            Debug.LogWarning("Duplicate GameManager instance detected.");
        }
    }

    /// <summary>
    /// Saves the player's current health.
    /// </summary>
    /// <param name="health">The player's current health value.</param>
    public void SavePlayerHealth(float health)
    {
        playerHealth = health;
        Debug.Log("Saved player health: " + playerHealth);
    }

    /// <summary>
    /// Loads and returns the saved player health.
    /// </summary>
    /// <returns>The saved player health value.</returns>
    public float LoadPlayerHealth()
    {
        Debug.Log("Loaded player health: " + playerHealth);
        return playerHealth;
    }

    /// <summary>
    /// Saves the name of the current weapon.
    /// </summary>
    /// <param name="weaponName">The name of the current weapon.</param>
    public void SaveWeaponState(string weaponName)
    {
        currentWeaponName = weaponName;
        Debug.Log("Saved weapon: " + currentWeaponName);
    }

    /// <summary>
    /// Loads and returns the saved weapon name.
    /// </summary>
    /// <returns>The saved weapon name.</returns>
    public string LoadWeaponState()
    {
        Debug.Log("Loaded weapon: " + currentWeaponName);
        return currentWeaponName;
    }

    /// <summary>
    /// Saves the game settings including audio volume, quality level, and fullscreen mode.
    /// </summary>
    /// <param name="volume">The audio volume level to save.</param>
    /// <param name="quality">The game quality level to save.</param>
    /// <param name="fullscreen">The fullscreen mode to save.</param>
    public void SaveSettings(float volume, int quality, bool fullscreen)
    {
        audioVolume = volume;
        qualityLevel = quality;
        isFullscreen = fullscreen;
        Debug.Log($"Saved settings - Volume: {audioVolume}, Quality: {qualityLevel}, Fullscreen: {isFullscreen}");
    }

    /// <summary>
    /// Loads and applies the saved game settings.
    /// </summary>
    public void LoadSettings()
    {
        Debug.Log($"Loaded settings - Volume: {audioVolume}, Quality: {qualityLevel}, Fullscreen: {isFullscreen}");
    }

    /// <summary>
    /// Sets the objective item as picked up.
    /// </summary>
    public void ObjectiveItemPickedUp()
    {
        objectiveItemPickedUp = true;
    }

    /// <summary>
    /// Checks if the objective item has been picked up.
    /// </summary>
    /// <returns>True if the objective item has been picked up, otherwise false.</returns>
    public bool IsObjectiveItemPickedUp()
    {
        return objectiveItemPickedUp;
    }
}
