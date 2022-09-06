using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementTopDown : MonoBehaviour //Gives movement to the player and sets its run and jump animation
{
    public PlayerControllerTopDown controller;

    [Range(0, 200f)] public float moveSpeed = 10f;

    //private Vector2 movement;

    float horizontalMove = 0f;
    float verticalMove = 0f;

    public Animator anim;
    public AnimationCurve jumpCurve;

    public SpriteRenderer spriteRenderer;
    public GameObject playerShadow;

    public bool isJumping;
    public void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        PlayerMovement();

        if (Input.GetButtonDown("Jump"))
        {
            print("jump pressed");
            Jump(1.0f, 0.0f);
        }
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
    public void Jump(float jumpHeightScale, float jumpPushScale)
    {

        if (!isJumping)
        {
            StartCoroutine(PlayerJump(jumpHeightScale, jumpPushScale));
        }
    }
    public IEnumerator PlayerJump(float jumpHeightScale, float jumpPushScale)
    {
        isJumping = true;
        float jumpStartTime = Time.deltaTime;
        float jumpDuration = 2;

        while (isJumping)
        {
            float jumpComplatePercentage = (Time.time - jumpStartTime) / jumpDuration;

            jumpComplatePercentage = Mathf.Clamp01(jumpComplatePercentage);

            gameObject.transform.localScale = Vector3.one + Vector3.one * jumpCurve.Evaluate(jumpComplatePercentage) * jumpHeightScale;

            playerShadow.transform.localScale = this.transform.localScale * 0.75f;

            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            if (jumpComplatePercentage == 1.0f)
                break;

            yield return null;
        }

        gameObject.transform.localScale = Vector3.one;
        playerShadow.transform.localScale = gameObject.transform.localScale;

        isJumping = false;
    }
}
