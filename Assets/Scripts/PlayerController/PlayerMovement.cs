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

    private GameObject menuUI;

    private Animator animator;

    [SerializeField] private int speed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        interactText.gameObject.SetActive(false);
        
        canMove = true;
        debugUI = FindObjectOfType<DebugFunctions>().gameObject.transform.parent.gameObject;
        mapUI = FindObjectOfType<MapController>().gameObject;
        menuUI = FindObjectOfType<MenuUIManager>().gameObject;
        OnMap();
        OnDebug();
        OnMenu();
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

    //Changing this to better work with the animator stuff with code I already have, if you need this function feel free to tell me and ill fix it -Alison
    //public void OnMove(InputValue iValue)
    //{
    //direction = iValue.Get<Vector2>();
    //}

    public void OnMove(InputValue iValue)
    {
        direction = iValue.Get<Vector2>();

        if(direction.x != 0 || direction.y != 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);

        animator.SetFloat("InputX", direction.x);
        animator.SetFloat("InputY", direction.y);

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
        {
            debugUI.SetActive(!debugUI.activeSelf);
        }
    }

    public void OnMenu()
    {
        if(menuUI != null)
        {
            menuUI.SetActive(!menuUI.activeSelf);
        }
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
