using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTopDown : MonoBehaviour //Gives movement to the player and sets its run and jump animation
{
    public PlayerControllerTopDown controller;

    [Range(0, 200f)] public float moveSpeed = 10f;

    //private Vector2 movement;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    public void Start()
    {

    }
    void Update()
    {
        PlayerMovement();
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
    }
    /*void MovementInput()
    {
        float mx = movement.x = Input.GetAxisRaw("Horizontal");
        float my = movement.y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(mx, my).normalized;
    }*/

    public void PlayerMovement()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * moveSpeed;
    }
}
