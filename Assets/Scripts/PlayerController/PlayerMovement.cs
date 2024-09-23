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

    private GameObject mapUI;

    private GameObject debugUI;

    [SerializeField] private int speed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        interactText.gameObject.SetActive(false);
        
        canMove = true;
        debugUI = FindObjectOfType<DebugFunctions>().gameObject.transform.parent.gameObject;
        mapUI = FindObjectOfType<MapController>().gameObject;
        OnMap();
        OnDebug();
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
        {
            InteractableEntity[] toInteract = interactObject.GetComponents<InteractableEntity>();
            foreach(InteractableEntity i in toInteract)
            {
                i.OnInteract();
            }
        }
            
    }

    public void OnContinue()
    {
        FindObjectOfType<DialogueManager>().OnContinue();
    }


    public void OnMove(InputValue iValue)
    {
       direction = iValue.Get<Vector2>();
    }

    public void OnMap()
    {
        if(mapUI != null)
        {
            canMove = mapUI.activeSelf;
            mapUI.SetActive(!mapUI.activeSelf);
        }
        
    }

    public void OnDebug()
    {
        if (debugUI != null)
            debugUI.SetActive(!debugUI.activeSelf);
    }



    void Update()
    {
        if (canMove)
        {
            rb.velocity = direction * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
}
