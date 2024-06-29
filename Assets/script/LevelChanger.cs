using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    public int levelToLoad;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FadeTolevel(1);
        }
    }
    public void FadeTolevel (int LevelIndex)
    {
        animator.SetTrigger("Fadeout");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
