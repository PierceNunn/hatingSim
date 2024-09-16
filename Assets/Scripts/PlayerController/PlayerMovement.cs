using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TMP_Text interactText;
    [SerializeField] private GameObject player;

    [SerializeField] private PlayerInput playerInput;

    private Rigidbody2D rb;

    private Vector2 direction;

    private int speed;

    private InputAction move;
    private InputAction select;

    private bool isMoving;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        interactText.gameObject.SetActive(false);

        playerInput.currentActionMap.Enable();
        playerInput.actions.FindActionMap("Player");
        move = playerInput.currentActionMap.FindAction("Move");
        select = playerInput.currentActionMap.FindAction("Select");

        speed = 2;

        isMoving = false; 

        move.started += Move_started;
        move.canceled += Move_Canceled;
    }

    private void Move_started(InputAction.CallbackContext obj)
    {
        isMoving = true;
        direction = obj.ReadValue<Vector2>();
    }

    private void Move_Canceled(InputAction.CallbackContext obj)
    {
        isMoving = false;
    }

    public void InteractTextChange(bool x)
    {
        interactText.gameObject.SetActive(x);
    }

    

    void Update()
    {
        if (isMoving)
        {
            rb.velocity = direction * speed;
        }
    }
}
