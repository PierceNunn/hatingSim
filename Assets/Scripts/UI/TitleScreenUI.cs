using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    public void Quit()
    {
       Application.Quit();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("School");
    }
}
