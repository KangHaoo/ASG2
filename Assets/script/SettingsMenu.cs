/// <author>Kang Hao</author>
/// <date>2024-06-26</date>
/// <summary>
/// Controls the settings menu functionality, including volume, quality settings, and fullscreen mode.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // The AudioMixer to control volume

    /// <summary>
    /// Sets the volume level in the AudioMixer.
    /// </summary>
    /// <param name="volume">The volume level to set.</param>
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume); // Set volume in AudioMixer
        if (GameManager.instance != null)
        {
            GameManager.instance.SaveSettings(volume, QualitySettings.GetQualityLevel(), Screen.fullScreen); // Save settings in GameManager
        }
    }

    /// <summary>
    /// Sets the quality level of the game.
    /// </summary>
    /// <param name="qualityIndex">Index of the quality level to set.</param>
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex); // Set quality level
        if (GameManager.instance != null)
        {
            GameManager.instance.SaveSettings(GetVolume(), qualityIndex, Screen.fullScreen); // Save settings in GameManager
        }
    }

    /// <summary>
    /// Sets whether the game should run in fullscreen mode.
    /// </summary>
    /// <param name="isFullscreen">True to enable fullscreen, false otherwise.</param>
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen; // Set fullscreen mode
        if (GameManager.instance != null)
        {
            GameManager.instance.SaveSettings(GetVolume(), QualitySettings.GetQualityLevel(), isFullscreen); // Save settings in GameManager
        }
    }

    /// <summary>
    /// Retrieves the current volume level from the AudioMixer.
    /// </summary>
    /// <returns>The current volume level.</returns>
    private float GetVolume()
    {
        float volume;
        audioMixer.GetFloat("volume", out volume); // Get volume from AudioMixer
        return volume;
    }
}
