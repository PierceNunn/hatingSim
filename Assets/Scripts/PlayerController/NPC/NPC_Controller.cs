using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC_Controller : MonoBehaviour
{
    private bool isTriggered;

    private PlayerMovement pM;

    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
        isTriggered = false;


    }

    //When entering a hitbox & pressing space, interaction event should be able to happen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        pM.InteractTextChange(true);
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pM.InteractTextChange(false);
        isTriggered = false;
    }

    void Update()
    {
        
    }
}
