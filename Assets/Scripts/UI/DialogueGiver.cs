using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XNode;

/*
 * DialogueGiver is where dialogue is actually stored
 * the InitiateDialogue function also needs to be called to push the stored
 * dialogue to the text box/UI
 */
public class DialogueGiver : InteractableEntity
{
    [SerializeField] private LinkedNode _dialogueToGive;
    [SerializeField] private bool _giveDialogueOnStart;
    [SerializeField] private bool _onlyAllowDialogueOnce;
    [SerializeField] private bool _advanceDayAfterTalk = false;

    private GameObject npc;

    public LinkedNode DialogueToGive { get => _dialogueToGive; 
        set => _dialogueToGive = value; }
    public GameObject Npc { get => npc; set => npc = value; }

    private void Start()
    {
        Npc = gameObject;
        if(_giveDialogueOnStart)
        {
            // !! REPLACE INVOKE !!
            Invoke("InitiateDialogue", 1f);
        }
    }

    override public void OnInteract()
    {
        // !! REPLACE INVOKE !!
        Invoke("InitiateDialogue", 0.1f);
    }
    public void InitiateDialogue()
    {
        if(this.isActiveAndEnabled)
        {
            //if there's a graph on the object get the Intro Node from there
            if (GetComponent<DialogueSceneGraph>() != null)
            {
                _dialogueToGive = GetComponent<DialogueSceneGraph>().graph.findIntroNode();
            }
            //send the stored Intro Node to the DialogueManager
            FindObjectOfType<DialogueManager>().StartDialogue(DialogueToGive, Npc, false);

            if (_onlyAllowDialogueOnce)
                Destroy(gameObject);
        }
        
    }

    public void EndDialogueBehavior()
    {
        if(_advanceDayAfterTalk)
        {
            print("advance day");
            TimeUIManager.AdvanceTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
