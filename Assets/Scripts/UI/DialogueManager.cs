using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
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
    [SerializeField] private Image _buttonPrompt;
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
    public void OnInteract()
    {
        if (IsOpen && !_autoAdvance)
        {
            if (isTyping) //allows showing all dialogue instantly
            {
                isTyping = false;
                StopAllCoroutines();
                _dialogueText.text = sentence;
                _buttonPrompt.enabled = true;
            }
            else
                DisplayNextSentence();
        }
    }

    /// <summary>
    /// initializes a conversation from an outside source.
    /// </summary>
    /// <param name="dialogue">A SingleDialogue array containing information for the initialized conversation.</param>
    /// <param name="NPC">The GameObject which initiates the conversation.</param>
    /// <param name="willAutoAdvance">Determines if dialogue will advance automatically.</param>
    public void StartDialogue(LinkedNode branchDialogue, GameObject NPC, bool willAutoAdvance)
    {
        IsOpen = true;
        _NPCDialogue.SetActive(true);
        _playerResponses.SetActive(false);
        currentBranchDialogue = branchDialogue.NextNode as DialogueNode;
        SingleDialogue dialogue = currentBranchDialogue.Dialogue;
        _autoAdvance = willAutoAdvance;
        currentRef = NPC;

        //set ui components to what they should be for the first dialogue
        _nameText.text = dialogue.TalkerData.CharacterName;
        _portrait.sprite = dialogue.TalkerData.CharacterPortrait;
        _portrait.SetNativeSize(); //just in case any portraits have different dimensions

        if (branchDialogue.GetType().ToString().Equals("DialogueNode"))
            nextBranchDialogue = branchDialogue;
        else
            nextBranchDialogue = branchDialogue.NextNode;
        //display the first sentence
        DisplayNextSentence();

    }

    public void OnContinue()
    {
        DisplayNextSentence();
    }

    /// <summary>
    /// Displays the next sentence in the queue.
    /// </summary>
    public void DisplayNextSentence()
    {
        if(nextBranchDialogue == null) //ends conversation if no more nodes
        {
            EndDialogue();
            return;
        }

        if (nextBranchDialogue.GetType().ToString().Equals("DialogueNode"))
        {
            //if next node is a DialogueNode next sentence can display normally
            currentBranchDialogue = nextBranchDialogue as DialogueNode;
        }
        else if(nextBranchDialogue.GetType().ToString().Equals("DialogueBranchNode"))
        {
            //if next node is DialogueBranch set up dialogue choices
            SetUpDialogueChoices(nextBranchDialogue as DialogueBranchNode);
            return;
        }
        else if (nextBranchDialogue.GetType().ToString().Equals("ChoiceNode"))
        {
            //if next node is a choice proceed to the next node
            LinkedNode t = nextBranchDialogue as LinkedNode;
            nextBranchDialogue = t.NextNode;
            return;
        }

        SingleDialogue dialogue = currentBranchDialogue.Dialogue;
        sentence = dialogue.sentences;
        string nameTag = dialogue.TalkerData.CharacterName;
        Sprite talkIMG = dialogue.TalkerData.CharacterPortrait;
        AudioClip[] voice = null;// dialogue.voice.clips;
        UnityEvent[] actions = dialogue.EventsToInvoke;


        print(sentence);

        //coroutine for sentence so it can appear letter by letter
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence, voice));
        //update ui elements
        _nameText.text = nameTag;
        _portrait.sprite = talkIMG;
        _portrait.SetNativeSize(); //just in case any portraits have different dimensions
        //play button sound
        //_buttonSound.GetComponent<AudioSource>().Play();


        //_buttonPrompt.enabled = false;

        foreach (UnityEvent e in actions)
        {
            e.Invoke();
        }

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

        _dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            _dialogueText.text += letter; //add letters of sentence individually
            //clip isn't played for specific characters or when no voice is available
            if (voice != null && letter != " "[0] && letter != ","[0] && letter != "'"[0])
            {
                int randomVChoice = Random.Range(0, voice.Length);
                //_voicer.clip = voice[randomVChoice];
                // _voicer.Play();
            }

            yield return new WaitForSeconds(_chatSpeed); //wait until the next letter
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
    /// mode, depending on whether or not more chunks are referenced.
    /// </summary>
    public void EndDialogue()
    {
        StopAllCoroutines();
        if (IsOpen)
        {

            //animator.SetBool("isOpen", false);
            Debug.Log("End of convo");

            IsOpen = false;
            //FindObjectOfType<PlayerController>().talking = false;
            _NPCDialogue.SetActive(false);
            _playerResponses.SetActive(false);


        }



    }

    void SetUpDialogueChoices(DialogueBranchNode branchNode)
    {
        if (branchNode.nextNodes.Length > 0)
        {
            _playerResponses.SetActive(true);
            for (int i = 0; i < _responseButtons.Length; i++)
            {
                //sets buttons to each choice for this chunk of dialogue
                if (i < branchNode.nextNodes.Length)
                {
                    ChoiceNode temp = branchNode.nextNodes[i] as ChoiceNode;
                    _responseButtons[i].SetActive(true);
                    if(temp.GetType().ToString().Equals("ItemChoiceNode"))
                    {
                        ItemChoiceNode tempChoice = temp as ItemChoiceNode;
                        if(PlayerPrefs.GetInt(tempChoice.RequiredItem, 0) != 1)
                        {
                            _responseButtons[i].GetComponentInChildren<TextMeshProUGUI>().text
                                = "LOCKED";
                            _responseButtons[i].GetComponent<Button>().interactable = false;
                            continue;
                        }
                    }
                    _responseButtons[i].GetComponent<Button>().interactable = true;
                    _responseButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = temp.ChoiceLabel;
                    _responseButtons[i].GetComponent<DialogueGiver>().DialogueToGive = temp.NextNode as DialogueNode;
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

