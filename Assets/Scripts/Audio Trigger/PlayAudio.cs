using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource AudioSource;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player" && !AudioSource.isPlaying)
        {
            AudioSource.Play();
        }
    }
}
