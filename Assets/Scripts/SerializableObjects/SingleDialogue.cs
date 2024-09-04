using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SingleDialogue
{
    [SerializeField] private CharacterData _talkerData;
    [SerializeField] private UnityEvent[] _eventsToInvoke; //for calling events mid-conversation
    [TextArea(3, 10)]
    [SerializeField] private string _sentences;

    public UnityEvent[] EventsToInvoke { get => _eventsToInvoke; set => _eventsToInvoke = value; }
    public string sentences { get => _sentences; set => _sentences = value; }
}

[System.Serializable]
public class MultiDialogue // for easy storage of repeat interacts
{
    public SingleDialogue[] dialogue;
}
