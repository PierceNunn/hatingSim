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

        UpdateEvidenceDisplay();
    }

    private void UpdateEvidenceDisplay()
    {
        //update displayed evidence
    }
}
