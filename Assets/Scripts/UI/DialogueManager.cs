using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using XNode;

/// <summary>
/// controls the text box and displays dialogue and profile images for conversations.
/// </summary>
public class DialogueManager : MonoBehaviour
{

    //components of ui
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _dialogueText;
    [SerializeField] private Image _portrait;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _voicer;
    [SerializeField] private GameObject _buttonSound;
    //[SerializeField] private Image _buttonPrompt;
    [SerializeField] private GameObject _playerResponses;
    [SerializeField] private GameObject[] _responseButtons;
    //dialogue settings
    [SerializeField] private float _chatSpeed = 0f;
    [SerializeField] private bool _autoAdvance = false;

    [SerializeField] private GameObject _NPCDialogue;

    private GameObject currentRef;
    private DialogueNode currentBranchDialogue;
    private Node nextBranchDialogue;
    private bool isOpen = false;
    private bool isTyping = false;
    private string sentence;

    public bool IsOpen { get => isOpen; set => isOpen = value; }


    /// <summary>
    /// Displays the next sentence when the assigned Interact key is pressed.
    /// </summary>
    public void OnContinue()
    {
        if (IsOpen && !_autoAdvance)
        {
            if (isTyping) //allows showing all dialogue instantly
            {
                isTyping = false;
                StopAllCoroutines();

                _dialogueText.maxVisibleCharacters = sentence.ToCharArray().Length;
                //_buttonPrompt.enabled = true;
            }
            else
                DisplayNextSentence();
        }
    }

    /// <summary>
    /// initializes a conversation from an outside source.
    /// </summary>
    /// <param name="branchDialogue">The current node of dialogue.</param>
    /// <param name="NPC">The GameObject which initiates the conversation.</param>
    /// <param name="willAutoAdvance">Determines if dialogue will advance automatically.</param>
    public void StartDialogue(LinkedNode branchDialogue, GameObject NPC, bool willAutoAdvance)
    {
        FindObjectOfType<PlayerInput>().actions.FindActionMap("UI").Enable();
        FindObjectOfType<PlayerInput>().actions.FindActionMap("Player").Disable();
        IsOpen = true;
        _NPCDialogue.SetActive(true); //show text box
        _playerResponses.SetActive(false); //hide choice buttons
        currentBranchDialogue = branchDialogue.NextNode as DialogueNode;
        _autoAdvance = willAutoAdvance;
        currentRef = NPC;

        if (branchDialogue.GetType().ToString().Equals("DialogueNode"))
            //displays input node if it's a dialogueNode
            nextBranchDialogue = branchDialogue;
        else
            //displays input node's next node if it isn't dialogue
            nextBranchDialogue = branchDialogue.NextNode;
        //display the first sentence
        DisplayNextSentence();

    }


    /// <summary>
    /// Displays the next sentence in the queue.
    /// </summary>
    public void DisplayNextSentence()
    {
        StopAllCoroutines();
        if (nextBranchDialogue == null) //ends conversation if no more nodes
        {
            EndDialogue();
            return;
        }

        string nextNodeType = nextBranchDialogue.GetType().ToString();
        if (nextNodeType.Equals("DialogueNode"))
        {
            //if next node is a DialogueNode next sentence can display normally
            currentBranchDialogue = nextBranchDialogue as DialogueNode;
        }
        else if (nextNodeType.Equals("ItemGiverNode"))
        {
            //first give player item defined in node
            ItemGiverNode temp = nextBranchDialogue as ItemGiverNode;
            temp.ItemToGive.CollectItem();
            //then next sentence can display normally
            currentBranchDialogue = nextBranchDialogue as DialogueNode;
        }
        else if (nextNodeType.Equals("AutoDialogueBranchNode"))
        {
            AutoSelectDialogueChoices(nextBranchDialogue as DialogueBranchNode);
        }
        else if(nextNodeType.Equals("DialogueBranchNode"))
        {
            print("dialogue branch node");
            //if next node is DialogueBranch set up dialogue choices
            SetUpDialogueChoices(nextBranchDialogue as DialogueBranchNode);
            return;
        }
        else if (nextNodeType.Equals("ChoiceNode"))
        {
            print("choice node");
            //if next node is a choice proceed to the next node
            LinkedNode t = nextBranchDialogue as LinkedNode;
            nextBranchDialogue = t.NextNode;
            return;
        }
        //if node isn't of above types then it's a dialogueNode

        //pull SingleDialogue data out of current node
        SingleDialogue dialogue = currentBranchDialogue.Dialogue;
        //pull current dialogue text out of the SingleDialogue data
        sentence = dialogue.sentences;
        //pull current talker's name out of the SingleDialogue's TalkerData
        string nameTag = dialogue.TalkerData.CharacterName;
        //pull current talker's portrait out of the SingleDialogue's TalkerData
        Sprite talkIMG = dialogue.TalkerData.GetPortraitByID(dialogue.PortraitID);
        AudioClip[] voice = dialogue.TalkerData.CharacterVoice.clips;
        UnityEvent[] actions = dialogue.EventsToInvoke;

        //print dialogue text (for debug mostly)
        print(sentence);

        //Stop all coroutines to prevent complications
        StopAllCoroutines();
        //Start coroutine to type out dialogue text
        StartCoroutine(TypeSentence(sentence, voice));
        //update ui elements
        _nameText.text = nameTag;
        _portrait.sprite = talkIMG;
        _portrait.SetNativeSize(); //just in case any portraits have different dimensions
        //play button sound
        //_buttonSound.GetComponent<AudioSource>().Play();


        //_buttonPrompt.enabled = false;

        //invoke UnityEvents tied to dialogue node
        foreach (UnityEvent e in actions)
        {
            e.Invoke();
        }

        //prepare next node for next call of DisplayNextSentence
        nextBranchDialogue = currentBranchDialogue.NextNode;
    }

    /// <summary>
    /// Makes a sentence in dialogue appear one letter at a time, as well as play the associated voice clip(s).
    /// </summary>
    /// <param name="sentence">The string to be displayed as a sentence.</param>
    /// <param name="voice">An array of AudioClips to be used as the voice.</param>
    /// <returns></returns>
    IEnumerator TypeSentence(string sentence, AudioClip[] voice)
    {
        isTyping = true;

        _dialogueText.maxVisibleCharacters = 0;
        _dialogueText.text = sentence;
        char[] sentenceCharArray = sentence.ToCharArray();

        for (int i = 0; i < sentenceCharArray.Length; i++)
        {
            char letter = sentenceCharArray[i];

            _dialogueText.maxVisibleCharacters++;

            //clip isn't played for specific chars or when no voice is available
            if (voice != null && letter != " "[0] && letter != ","[0] && letter != "'"[0])
            {
                int randomVChoice = Random.Range(0, voice.Length);
                _voicer.clip = voice[randomVChoice];
                _voicer.Play();
            }

            //wait pre-specified time until printing the next letter
            yield return new WaitForSeconds(_chatSpeed);
        }

        isTyping = false;

        if (_autoAdvance) //go straight to next sentence if autoAdvance is on
        {
            DisplayNextSentence();
        }
        //_buttonPrompt.enabled = true;
    }


    /// <summary>
    /// transitions to either displaying next choices or exits dialogue
    /// mode, depending on whether or not more nodes are referenced.
    /// </summary>
    public void EndDialogue()
    {
        //stop all coroutines to prevent complications
        StopAllCoroutines();
        if (IsOpen)
        {

            //animator.SetBool("isOpen", false);
            Debug.Log("End of convo");

            IsOpen = false;
            _NPCDialogue.SetActive(false);
            _playerResponses.SetActive(false);
            FindObjectOfType<PlayerInput>().actions.FindActionMap("Player").Enable();
            currentRef.GetComponent<DialogueGiver>().EndDialogueBehavior();


        }



    }

    void AutoSelectDialogueChoices(DialogueBranchNode branchNode)
    {
        foreach(ChoiceNode c in branchNode.nextNodes)
        {
            //automatically choose the first available dialogue option in the node
            if(c.IsSelectable())
            {
                StartDialogue(c.NextNode as DialogueNode, currentRef, _autoAdvance);
                return;
            }
        }
    }

    void SetUpDialogueChoices(DialogueBranchNode branchNode)
    {
        //first check if there are any choices set up
        if (branchNode.nextNodes.Length > 0)
        {
            //show choice buttons
            _playerResponses.SetActive(true);
            for (int i = 0; i < _responseButtons.Length; i++)
            {
                //sets buttons to each choice for this chunk of dialogue
                if (i < branchNode.nextNodes.Length)
                {
                    ChoiceNode temp = branchNode.nextNodes[i] as ChoiceNode;
                    _responseButtons[i].SetActive(true);

                    //make button "locked" if corresponding choice is labeled as not selectable
                    if(!temp.IsSelectable())
                    {
                        _responseButtons[i].GetComponentInChildren<TextMeshProUGUI>().text
                                = "LOCKED";
                        _responseButtons[i].GetComponent<Button>().interactable = false;
                        continue;
                    }
                        
                    //sets button text and stored node to choice's data
                    _responseButtons[i].GetComponent<Button>().interactable = true;
                    _responseButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = temp.ChoiceLabel;
                    _responseButtons[i].GetComponent<DialogueGiver>().DialogueToGive = temp.NextNode as DialogueNode;
                    _responseButtons[i].GetComponent<DialogueGiver>().Npc = currentRef;
                }
                //hides any extra buttons
                else
                {
                    _responseButtons[i].SetActive(false);
                }
            }

        }
    }

}

