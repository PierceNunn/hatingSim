using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaryUIHandler : MonoBehaviour
{
    [SerializeField] private CharacterData[] _displayedCharacters;
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private TextMeshProUGUI _characterBio;
    [SerializeField] private Image _characterImage;
    [SerializeField] private Image[] _evidenceImages;
    [SerializeField] private Image[] _characterButtons;

    private CharacterData currentChar;

    private void Start()
    {
        SetUpDiaryUI();
    }

    private void SetUpDiaryUI()
    {
        for(int i = 0; i < _displayedCharacters.Length; i++)
        {
            _characterButtons[i].gameObject.SetActive(true);
            _characterButtons[i].sprite = _displayedCharacters[i].DefaultCharacterPortrait;
        }
    }

    public void DisplayCharacterInfo(int index)
    {
        currentChar = _displayedCharacters[index];
        _characterName.text = currentChar.CharacterName;
        _characterBio.text = currentChar.CharacterBio;
        UpdateEvidenceDisplay(currentChar);
    }

    public void DisplayEvidenceInfo(int index)
    {
        _characterName.text = currentChar.RelevantEvidence[index].ItemID;
        _characterBio.text = currentChar.RelevantEvidence[index].ItemBio;
    }

    private void UpdateEvidenceDisplay(CharacterData currentChar)
    {
        for(int i = 0; i < _evidenceImages.Length; i++)
        {
            if(currentChar.RelevantEvidence.Length > i)
            {
                _evidenceImages[i].enabled = true;
                _evidenceImages[i].sprite = currentChar.RelevantEvidence[i].ItemImage;

                if(CollectibleItem.IsItemCollected(currentChar.RelevantEvidence[i]))
                    _evidenceImages[i].color = Color.black;
                else
                    _evidenceImages[i].color = Color.white;

            }
            else
            {
                _evidenceImages[i].enabled = false;
            }
        }
    }
}
