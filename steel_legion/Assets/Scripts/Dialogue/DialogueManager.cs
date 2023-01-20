using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentence.Queue.Enqueue(sentence);
        }
    }
}
