using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * CharacterData stores, unsurprisingly, data related to a specific character
 * this includes name, portraits, and audio clips
 * combining all of this into a single asset makes referencing characters in
 * things like dialogue much more convenient as all related assets are bundled
 * together
 */
[CreateAssetMenu]
public class CharacterData : ScriptableObject
{
    [SerializeField] private string _characterName;
    [SerializeField] private Sprite _defaultCharacterPortrait;
    [SerializeField] private Portrait[] _portraits;
    [SerializeField] private RandomizedAudio _characterVoice;

    public string CharacterName { get => _characterName; set => _characterName = value; }
    public Sprite DefaultCharacterPortrait { get => _defaultCharacterPortrait; set => _defaultCharacterPortrait = value; }
    public RandomizedAudio CharacterVoice { get => _characterVoice; set => _characterVoice = value; }
    public Portrait[] Portraits { get => _portraits; set => _portraits = value; }

    public Sprite GetPortraitByID(string id)
    {
        foreach(Portrait p in _portraits)
        {
            if(p.PortraitID.Equals(id))
            {
                return p.PortraitImage;
            }
        }
        return _defaultCharacterPortrait;
    }
}
