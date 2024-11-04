using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileMapTeleport : MonoBehaviour
{
    //VERTICAL SLICE YAY!!!!!!!!!!
    [SerializeField] private GameObject toArea;
    [SerializeField] private CollectibleItem dependantItem;
    private int day;
    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = toArea.transform.position;
    }

    public CollectibleItem ReturnDependant()
    {
        return dependantItem;
    }


    void Update()
    {
        
    }
}
