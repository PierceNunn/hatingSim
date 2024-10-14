using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileMapTeleport : MonoBehaviour
{
    [SerializeField] private GameObject toArea;
    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = toArea.transform.position;  
    }


    void Update()
    {
        
    }
}