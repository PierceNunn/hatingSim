using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        FindObjectOfType<MapController>().ToggleVisibility();
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
