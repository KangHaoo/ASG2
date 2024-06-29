using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menu; // Assign your menu GameObject in the inspector

    private void Update()
    {
        if (GameManager.instance.IsObjectiveItemPickedUp() && Input.GetKeyDown(KeyCode.M))
        {
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
}

