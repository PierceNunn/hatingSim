using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

/*
 * DialogueGiver is where dialogue is actually stored
 * the InitiateDialogue function also needs to be called to push the stored
 * dialogue to the text box/UI
 */
public class DialogueGiver : MonoBehaviour
{
    [SerializeField] private LinkedNode _dialogueToGive;
    [SerializeField] private bool _giveDialogueOnStart;

    public LinkedNode DialogueToGive { get => _dialogueToGive; 
        set => _dialogueToGive = value; }

    private void Start()
    {
        if(_giveDialogueOnStart)
        {
            Invoke("InitiateDialogue", 1f);
        }
    }
    public void InitiateDialogue()
    {
        //if there's a graph on the object get the Intro Node from there
        if(GetComponent<DialogueSceneGraph>() != null)
        {
            _dialogueToGive = GetComponent<DialogueSceneGraph>().graph.findIntroNode();
        }
        //send the stored Intro Node to the DialogueManager
        FindObjectOfType<DialogueManager>().StartDialogue(DialogueToGive, gameObject, false);
    }
}
