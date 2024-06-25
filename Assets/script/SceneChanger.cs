using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetScene;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SavePlayerData(other.transform);
            ChangeScene();
        }
    }

    void SavePlayerData(Transform playerTransform)
    {
        PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
        PlayerPrefs.SetInt("TargetScene", targetScene);
        PlayerPrefs.Save();
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
