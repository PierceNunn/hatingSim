using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/*
 * SingleDialogue is the main form of storage for chunks of dialogue, holding
 * the speaking character, events to call when displayed, and of course the
 * dialogue text itself.
 */
[System.Serializable]
public class SingleDialogue
{
    [SerializeField] private CharacterData _talkerData;
    [SerializeField] private UnityEvent[] _eventsToInvoke; //for calling events mid-conversation
    [TextArea(3, 10)] //set size of text field in editor
    [SerializeField] private string _sentences;

    public UnityEvent[] EventsToInvoke { get => _eventsToInvoke; set => _eventsToInvoke = value; }
    public string sentences { get => _sentences; set => _sentences = value; }
    public CharacterData TalkerData { get => _talkerData; set => _talkerData = value; }
}
