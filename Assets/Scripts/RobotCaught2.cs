using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotCaught2 : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        SceneManager.LoadScene("RobotCaughtU2");
    }
}
