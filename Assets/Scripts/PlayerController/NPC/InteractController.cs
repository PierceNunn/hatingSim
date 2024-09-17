using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractController : MonoBehaviour
{
    private PlayerMovement pM;

    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
    }

    //When entering a hitbox & pressing space, interaction event should be able to happen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pM.InteractTextChange(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pM.InteractTextChange(false);
    }

    void Update()
    {
        
    }
}
