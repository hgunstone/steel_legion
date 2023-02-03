using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateLever : MonoBehaviour
{
    public GameObject leverHandle;

    public KeyCode useKey = KeyCode.E;

    bool playerInTrigger = false;

    private void Update()
    {
        if (playerInTrigger == true)
        {
            if (Input.GetKeyDown(useKey))
            {
                leverHandle.transform.Rotate(0f, 0f, -40f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerInTrigger = false;
        }
    }
}