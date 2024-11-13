using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileMapTeleport : MonoBehaviour
{
    //VERTICAL SLICE YAY!!!!!!!!!!
    [SerializeField] private GameObject toArea;
    //private int day;
    private GameObject player;
    [SerializeField] private bool _teleportOnStart = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        if(_teleportOnStart && this.isActiveAndEnabled && IsUsable())
        {
            Teleport();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && IsUsable())
        {
            Teleport();
        }
    }

    public void Teleport()
    {
        player.transform.position = toArea.transform.position;
    }

    public virtual bool IsUsable()
    {
        //base TileMapTeleport is always usable, altered for child classes
        return true;
    }
}
