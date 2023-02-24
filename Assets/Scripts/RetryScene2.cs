using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScene2 : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}

