using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDialogueButton : MonoBehaviour
{
    [SerializeField] public List<Dialogue> dialogue;
    int dialogueIndex = 0;

    public void NextDialogue()
    {
        if(dialogueIndex == dialogue.Count)
        {
            Debug.Log("No more dialogues");
            return;
        }
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue[dialogueIndex]);
        dialogueIndex++;
    }
}
