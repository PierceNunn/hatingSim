using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiaryUIHandler : MonoBehaviour
{
    [SerializeField] private CharacterData[] _displayedCharacters;
    [SerializeField] private TextMeshProUGUI _characterName;
    [SerializeField] private Image _characterImage;
    [SerializeField] private Image[] _evidenceImages;

    private int charIndex = 0;

    public void DisplayNextCharacter()
    {
        charIndex = charIndex + 1 >= _displayedCharacters.Length ? 0 : charIndex + 1;
        UpdateDiaryDisplay();
    }

    public void DisplayLastCharacter()
    {
        charIndex = charIndex - 1 < 0 ? _displayedCharacters.Length : charIndex - 1;
        UpdateDiaryDisplay();
    }

    private void UpdateDiaryDisplay()
    {
        CharacterData currentChar;

        try
        {
            currentChar = _displayedCharacters[charIndex];
        }
        catch
        {
            print("invalid character reference in DiaryUIHandler!!");
            return;
        }

        _characterName.text = currentChar.CharacterName;
        _characterImage.sprite = currentChar.DefaultCharacterPortrait;

        UpdateEvidenceDisplay(currentChar);
    }

    private void UpdateEvidenceDisplay(CharacterData currentChar)
    {
        for(int i = 0; i < _evidenceImages.Length; i++)
        {
            if(currentChar.RelevantEvidence.Length > i)
            {
                _evidenceImages[i].enabled = true;
                _evidenceImages[i].sprite = currentChar.RelevantEvidence[i].ItemImage;
            }
            else
            {
                _evidenceImages[i].enabled = false;
            }
        }
    }
}
