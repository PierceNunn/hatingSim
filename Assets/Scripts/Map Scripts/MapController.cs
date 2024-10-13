using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : MonoBehaviour
{
    [SerializeField] private GameObject[] locations;

    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }


    public void Courtyard()
    {
        player.transform.position = locations[0].transform.position;
    }

    public void Library()
    {
        player.transform.position = locations[1].transform.position;
    }

    public void Gym()
    {
        player.transform.position = locations[2].transform.position;
    }

    public void Classroom()
    {
        player.transform.position = locations[3].transform.position;
    }

    public void Store()
    {
        player.transform.position = locations[4].transform.position;
    }

    public void LoadScene(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

   // public void AdvanceTime()
   // {
    //    TimeUIManager.AdvanceTime();
    //    LoadScene(SceneManager.GetActiveScene().name);
    //}
}
