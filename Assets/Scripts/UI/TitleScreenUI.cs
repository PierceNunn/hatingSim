using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenUI : MonoBehaviour
{
    private int currentScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Quit()
    {
       Application.Quit();
    }

    public void GameStart()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene++);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
