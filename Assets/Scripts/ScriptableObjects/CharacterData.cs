using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private Sprite _characterPortrait;
    [SerializeField] private RandomizedAudio _characterVoice;

    public string CharacterName { get => _characterName; set => _characterName = value; }
    public Sprite CharacterPortrait { get => _characterPortrait; set => _characterPortrait = value; }
    public RandomizedAudio CharacterVoice { get => _characterVoice; set => _characterVoice = value; }
}
