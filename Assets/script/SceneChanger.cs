using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public int targetScene;
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            FadeToLevel(targetScene);
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        Debug.Log("Fade to level: " + levelIndex);
        targetScene = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        Debug.Log("Fade complete, loading scene: " + targetScene);
        SceneManager.LoadScene(targetScene);
    }
}
