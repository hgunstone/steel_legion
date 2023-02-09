using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemPickup : MonoBehaviour
{
    
    public float poemCounter;

    public GameObject poemDialogueTrigger;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "poem")
        {
            poemCounter += 1;

            Destroy(collider.gameObject);

            poemDialogueTrigger.transform.Translate(0, -10, 0);
        }
    }
}
