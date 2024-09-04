using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BranchingDialogue : ScriptableObject
{
    [SerializeField] private SingleDialogue[] _dialogue;
    [SerializeField] private DialogueResponse[] _responses;

    public SingleDialogue[] Dialogue { get => _dialogue; set => _dialogue = value; }
    public DialogueResponse[] Responses { get => _responses; set => _responses = value; }
}
