using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SingleDialogue
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _talkerIMG;
    [SerializeField] private RandomizedAudio _voice;
    [SerializeField] private bool _jitterText = false;
    [SerializeField] private UnityEvent[] _eventsToInvoke; //for calling events mid-conversation
    [TextArea(3, 10)]
    [SerializeField] private string _sentences;

    public string name { get => _name; set => _name = value; }
    public Sprite talkerIMG { get => _talkerIMG; set => _talkerIMG = value; }
    public RandomizedAudio voice { get => _voice; set => _voice = value; }
    public bool jitterText { get => _jitterText; set => _jitterText = value; }
    public UnityEvent[] EventsToInvoke { get => _eventsToInvoke; set => _eventsToInvoke = value; }
    public string sentences { get => _sentences; set => _sentences = value; }
}

[System.Serializable]
public class MultiDialogue // for easy storage of repeat interacts
{
    public SingleDialogue[] dialogue;
}
