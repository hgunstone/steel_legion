using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Dialogue dialogue; 

    public AudioSource my_source;
    public AudioClip sound;
    public float volume = 25f;

    public bool has_played = false;

    public void OnTriggerEnter()
    {
        if (!has_played)
        {
            my_source.PlayOneShot(sound, volume);
            has_played = true;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

    }
}
