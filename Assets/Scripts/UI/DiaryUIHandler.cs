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

    private void UpdateDiaryDisplay()
    {

    }
}
