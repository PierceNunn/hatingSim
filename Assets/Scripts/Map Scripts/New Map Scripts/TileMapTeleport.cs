using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileMapTeleport : MonoBehaviour
{
    [SerializeField] private GameObject toArea;
    [SerializeField] private GameObject player;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = toArea.transform.position;  
    }


    void Update()
    {
        
    }
}
