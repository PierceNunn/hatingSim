using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueResponse
{
    [SerializeField] private string _response;
    [SerializeField] private BranchingDialogue _resultingDialogue;

    public string Response { get => _response; set => _response = value; }
    public BranchingDialogue ResultingDialogue { get => _resultingDialogue; set => _resultingDialogue = value; }
}
