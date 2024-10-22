using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuUIHandler : MonoBehaviour
{
    public void ResumeGame()
    {
        transform.parent.gameObject.SetActive(!transform.parent.gameObject.activeSelf);
    }

    public void DisplayEvidence()
    {
        FindObjectOfType<DiaryUIHandler>().ToggleVisibility();
    }

    public void SaveGame()
    {
        GameManager.instance.SaveCollectedItems();
    }

    public void OpenMap()
    {

    }

    public void ReturnToMainMenu()
    {

    }
}
