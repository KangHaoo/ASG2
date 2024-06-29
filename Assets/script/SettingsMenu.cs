using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        if (GameManager.instance != null)
        {
            GameManager.instance.SaveSettings(volume, QualitySettings.GetQualityLevel(), Screen.fullScreen);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        if (GameManager.instance != null)
        {
            GameManager.instance.SaveSettings(GetVolume(), qualityIndex, Screen.fullScreen);
        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        if (GameManager.instance != null)
        {
            GameManager.instance.SaveSettings(GetVolume(), QualitySettings.GetQualityLevel(), isFullscreen);
        }
    }

    private float GetVolume()
    {
        float volume;
        audioMixer.GetFloat("volume", out volume);
        return volume;
    }
}
