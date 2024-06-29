using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float playerHealth = 100f;
    public string currentWeaponName;
    public float audioVolume = 0.75f;
    public int qualityLevel = 2;
    public bool isFullscreen = true;

    private bool objectiveItemPickedUp = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
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

    public void SavePlayerHealth(float health)
    {
        playerHealth = health;
        Debug.Log("Saved player health: " + playerHealth);
    }

    public float LoadPlayerHealth()
    {
        Debug.Log("Loaded player health: " + playerHealth);
        return playerHealth;
    }

    public void SaveWeaponState(string weaponName)
    {
        currentWeaponName = weaponName;
        Debug.Log("Saved weapon: " + currentWeaponName);
    }

    public string LoadWeaponState()
    {
        Debug.Log("Loaded weapon: " + currentWeaponName);
        return currentWeaponName;
    }

    public void SaveSettings(float volume, int quality, bool fullscreen)
    {
        audioVolume = volume;
        qualityLevel = quality;
        isFullscreen = fullscreen;
        Debug.Log($"Saved settings - Volume: {audioVolume}, Quality: {qualityLevel}, Fullscreen: {isFullscreen}");
    }

    public void LoadSettings()
    {
        Debug.Log($"Loaded settings - Volume: {audioVolume}, Quality: {qualityLevel}, Fullscreen: {isFullscreen}");
    }

    public void ObjectiveItemPickedUp()
    {
        objectiveItemPickedUp = true;
    }

    public bool IsObjectiveItemPickedUp()
    {
        return objectiveItemPickedUp;
    }
}
