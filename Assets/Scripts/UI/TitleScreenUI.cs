using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] private GameObject _outdatedSavePopup;

    private void Start()
    {
        //opens outdated save message if save is outdated (wow)
        if(!GameManager.instance.IsSaveFromCurrentVersion())
        {
            _outdatedSavePopup.SetActive(true);
        }
    }

    public void Quit()
    {
       Application.Quit();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("School");
    }
}
