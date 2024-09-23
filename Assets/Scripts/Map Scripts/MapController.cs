using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    public void Library()
    {
        SceneManager.LoadScene("Library");
    }

    public void Classroom()
    {
        SceneManager.LoadScene("Classroom");
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
