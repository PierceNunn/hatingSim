using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private Sprite _characterPortrait;
    [SerializeField] private RandomizedAudio _characterVoice;
}
