using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public KeyCode useKey = KeyCode.E;

    public void OnTriggerEnter()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
