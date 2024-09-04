using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField] private Sprite _characterPortrait;
    [SerializeField] private RandomizedAudio _characterVoice;
}
