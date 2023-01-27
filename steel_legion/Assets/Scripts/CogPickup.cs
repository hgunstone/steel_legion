using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CogPickup : MonoBehaviour
{
    public float cogsInLevel;
    public float cogCounter;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Cog")
        {
            cogCounter += 1;

            Destroy(collider.gameObject);
        }
    }
}