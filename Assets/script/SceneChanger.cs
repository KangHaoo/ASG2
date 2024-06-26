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
        //Help to save player location within the map/ scene
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
//PlayerPrefs is useful for storing simple data, but for more complex data or larger amounts of data,
//consider using other methods like serialization, databases, or Unity's JsonUtility for saving to files.