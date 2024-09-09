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

    private Queue<SingleDialogue> dialogues;
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
    private DialogueNodeGraph currentNodeGraph;
    private bool isOpen = false;
    private bool isTyping = false;
    private string sentence;
    private int convoLen = 0;

    public bool IsOpen { get => isOpen; set => isOpen = value; }

    /// <summary>
    /// sets each queue as a new empty queue.
    /// </summary>
    void Start()
    {
        dialogues = new Queue<SingleDialogue>();
    }

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
    public void StartDialogue(DialogueNode branchDialogue, GameObject NPC, bool willAutoAdvance)
    {
        IsOpen = true;
        _NPCDialogue.SetActive(true);
        _playerResponses.SetActive(false);
        currentNodeGraph = branchDialogue.graph as DialogueNodeGraph;
        DialogueNode temp = currentNodeGraph.findIntroNode().NextNode as DialogueNode;
        SingleDialogue dialogue = temp.Dialogue;
        _autoAdvance = willAutoAdvance;
        currentRef = NPC;
        //clear queue
        dialogues.Clear();
        //set queue to new queue
        dialogues = new Queue<SingleDialogue>();

        //set ui components to what they should be for the first dialogue
        _nameText.text = dialogue.TalkerData.CharacterName;
        _portrait.sprite = dialogue.TalkerData.CharacterPortrait;
        _portrait.SetNativeSize(); //just in case any portraits have different dimensions
        convoLen = 1;//dialogue.Length + 1;


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

        Node nextBranchDialogue;
        if (currentBranchDialogue == null)
            nextBranchDialogue = currentNodeGraph.findIntroNode().NextNode;
        else
            nextBranchDialogue = currentBranchDialogue.NextNode;
        if (nextBranchDialogue.GetType().ToString().Equals("DialogueNode"))
        {
            currentBranchDialogue = nextBranchDialogue as DialogueNode;
        }
        else if(nextBranchDialogue.GetType().ToString().Equals("DialogueBranchNode"))
        {
            SetUpDialogueChoices(nextBranchDialogue as DialogueBranchNode);
            return;
        }
        else
        {
            EndDialogue();
            return; //if ending don't run rest of the function
        }

        //dequeue element from each queue
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

