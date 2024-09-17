using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TMP_Text interactText;

    [SerializeField] private GameObject cam;


    private Rigidbody2D rb;

    private Vector2 direction;

    private GameObject interactObject;

    [SerializeField] private int speed;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        interactText.gameObject.SetActive(false);

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
        }
    }


    public void OnMove(InputValue iValue)
    {
        direction = iValue.Get<Vector2>();
    }



    void Update()
    {
        
        rb.velocity = direction * speed;

        cam.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
    }
}
