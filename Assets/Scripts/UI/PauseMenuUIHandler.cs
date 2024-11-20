using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenuUIHandler : MonoBehaviour
{
    public void ResumeGame()
    {
        if (!transform.parent.gameObject.activeSelf)
        {
            FindObjectOfType<PlayerInput>().actions.FindActionMap("UI").Enable();
            FindObjectOfType<PlayerInput>().actions.FindActionMap("Player").Disable();
        }
        else
        {
            FindObjectOfType<PlayerInput>().actions.FindActionMap("UI").Disable();
            FindObjectOfType<PlayerInput>().actions.FindActionMap("Player").Enable();
        }

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
        FindObjectOfType<MapController>().ToggleVisibility();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
