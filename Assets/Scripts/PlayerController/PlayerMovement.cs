using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TMP_Text interactText;

    private Rigidbody2D rb;

    private Vector2 direction;

    private GameObject interactObject;

    private bool canMove;

    private bool mapOpen;

    [SerializeField] private GameObject mapUI;

    [SerializeField] private int speed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        interactText.gameObject.SetActive(false);
        mapOpen = false;
        mapUI.SetActive(mapOpen);
        canMove = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<InteractableEntity>() != null)
        {
            interactObject = collision.gameObject;
            interactText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == interactObject)
        {
            interactObject = null;
            interactText.gameObject.SetActive(false);
        }
    }

    public void OnSelect()
    {
        if (interactObject != null)
            interactObject.GetComponent<InteractableEntity>().OnInteract();
    }

    public void OnContinue()
    {
        FindObjectOfType<DialogueManager>().OnContinue();
    }


    public void OnMove(InputValue iValue)
    {
        if (canMove)
        {
            direction = iValue.Get<Vector2>();
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    public void OnMap()
    {
        mapOpen = !mapOpen;
        canMove = !mapOpen;
        mapUI.SetActive(mapOpen);
    }



    void Update()
    {
        
        rb.velocity = direction * speed;

    }
}
