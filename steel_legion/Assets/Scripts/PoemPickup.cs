using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemPickup : MonoBehaviour
{
    
    public float poemCounter;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "poem")
        {
            poemCounter += 1;

            Destroy(collider.gameObject);
        }
    }
}
