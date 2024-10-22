using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    private PlayerMovement pM;

    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }

    void Update()
    {
        
    }
}
