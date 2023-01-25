using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScene : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Level 1 (outside tower)");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}

