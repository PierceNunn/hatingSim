using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGiver : MonoBehaviour
{
    [SerializeField] private BranchingDialogue _dialogueToGive;
    [SerializeField] private bool _giveDialogueOnStart;

    public BranchingDialogue DialogueToGive { get => _dialogueToGive; set => _dialogueToGive = value; }

    private void Start()
    {
        if(_giveDialogueOnStart)
        {
            Invoke("InitiateDialogue", 1f);
        }
    }
    public void InitiateDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(DialogueToGive, gameObject, false);
    }
}
