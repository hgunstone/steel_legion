using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter() // calls this function when you enter the trigger
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // goes to the next scene in the build index
    }
}
