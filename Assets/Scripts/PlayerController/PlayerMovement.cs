using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TMP_Text interactText;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject cam;

    [SerializeField] private PlayerInput playerInput;


    private Rigidbody2D rb;

    private Vector2 direction;

    [SerializeField] private int speed;

    private InputAction move;
    private InputAction select;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        interactText.gameObject.SetActive(false);

        move = playerInput.actions["Move"];
        select = playerInput.actions["Select"];

        select.started += Select_started;
    }

    private void Select_started(InputAction.CallbackContext obj)
    {

    }

    //changes the [Space] text when in an item's hit box
    public void InteractTextChange(bool x)
    {
        interactText.gameObject.SetActive(x);
    }



    void Update()
    {
        direction = move.ReadValue<Vector2>();
        rb.velocity = direction * speed;

        cam.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}