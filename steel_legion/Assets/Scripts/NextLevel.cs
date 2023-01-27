using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public CogPickup cog_pickup;

    void Start()
    {

    }

    private void OnTriggerEnter() // calls this function when you enter the trigger
    {
        if (cog_pickup.openDoor == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // goes to the next scene in the build index 
    }   } 
}