using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataLoader : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerX") && PlayerPrefs.HasKey("PlayerY") && PlayerPrefs.HasKey("PlayerZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerX");
            float y = PlayerPrefs.GetFloat("PlayerY");
            float z = PlayerPrefs.GetFloat("PlayerZ");

            player.transform.position = new Vector3(x, y, z);
        }
    }
}

// PlayerPrefs is useful for storing simple data, but for more complex data or larger amounts of data,
// consider using other methods like serialization, databases, or Unity's JsonUtility for saving to files.