using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject keyUIPrefab;
    public Transform inventoryUIParent;
    public KeyCode pickupKey = KeyCode.F;
    private int keysCollected = 0;
    private GameObject currentKey = null; // Track the current key GameObject

    private void Update()
    {
        if (currentKey != null && Input.GetKeyDown(pickupKey))
        {
            CollectKey();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            currentKey = other.gameObject; // Store the current key GameObject
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            currentKey = null; // Clear current key when leaving its trigger area
        }
    }

    private void CollectKey()
    {
        keysCollected++;
        UpdateInventoryUI();
        Destroy(currentKey); // Destroy the current key GameObject from the scene
    }

    private void UpdateInventoryUI()
    {
        // Instantiate a new key UI element
        GameObject keyUI = Instantiate(keyUIPrefab, inventoryUIParent);
        Text keyText = keyUI.GetComponent<Text>();
        keyText.text = "Key " + keysCollected.ToString();
    }
}

