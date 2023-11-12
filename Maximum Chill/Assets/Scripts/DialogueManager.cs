using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI charNameText;
    [SerializeField] TextMeshProUGUI dialogueText;

    Queue<string> names = new Queue<string>();
    Queue<string> dialogues = new Queue<string>();
    public bool finishedDialogue = false;
    // Start is called before the first frame update
    void Awake()
    {
        //names = new Queue<string>();
        //dialogues = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        names.Clear();
        dialogues.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            dialogues.Enqueue(sentence);
        }

        foreach (string name in dialogue.nameDisplays)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(dialogues.Count == 0)
        {
            EndDialogue();
            return;
        }
        string nextName = names.Dequeue();
        string nextSentence = dialogues.Dequeue();

        Debug.Log(nextName);
        charNameText.text = nextName;
        dialogueText.text = nextSentence;
    }

    public void EndDialogue()
    {
        finishedDialogue = true;
        Debug.Log("ENDED");
    }
}
