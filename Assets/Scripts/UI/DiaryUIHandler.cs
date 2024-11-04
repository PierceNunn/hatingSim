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
    [SerializeField] private GameObject _uiContents;

    private CharacterData currentChar;

    private void Start()
    {
        //i like to split "setup" functions out of Start for reusability
        SetUpDiaryUI();
    }

    private void SetUpDiaryUI()
    {
        for(int i = 0; i < _displayedCharacters.Length; i++)
        {
            _characterButtons[i].gameObject.SetActive(true);
            _characterButtons[i].sprite = _displayedCharacters[i].CharacterIcon;
        }
    }

    public void ToggleVisibility()
    {
        _uiContents.SetActive(!_uiContents.activeSelf);
    }

    public void DisplayCharacterInfo(int index)
    {
        //set all relevant text/images in UI to character's info
        currentChar = _displayedCharacters[index];
        _characterName.text = currentChar.CharacterName;
        _characterBio.text = currentChar.CharacterBio;
        //show relevant evidence in UI as well
        UpdateEvidenceDisplay(currentChar);
    }

    public void DisplayEvidenceInfo(int index)
    {
        //show name and bio of clicked on evidence
        _characterName.text = currentChar.RelevantEvidence[index].ItemID;
        _characterBio.text = currentChar.RelevantEvidence[index].ItemBio;
    }

    //show all the relevant evidence in the diary UI
    private void UpdateEvidenceDisplay(CharacterData currentChar)
    {
        for(int i = 0; i < _evidenceImages.Length; i++)
        {
            if(currentChar.RelevantEvidence.Length > i)
            {
                _evidenceImages[i].enabled = true;
                _evidenceImages[i].sprite = currentChar.RelevantEvidence[i].ItemImage;

                //make collectible sillohette if not collected
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
