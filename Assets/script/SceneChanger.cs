using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetScene;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}


//PlayerPrefs is useful for storing simple data, but for more complex data or larger amounts of data,
//consider using other methods like serialization, databases, or Unity's JsonUtility for saving to files.