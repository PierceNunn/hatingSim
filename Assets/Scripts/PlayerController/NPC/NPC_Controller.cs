using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Controller : MonoBehaviour
{
    private bool isTriggered;

    void Start()
    {
        isTriggered = false;
    }

    //When entering a hitbox & pressing space, interaction event should be able to happen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTriggered = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }

    void Update()
    {
        
    }
}
