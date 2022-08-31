using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinProperties : MonoBehaviour
{

    private Transform player;

    public float moveSpeed = 5;
    private Rigidbody2D rb;
    private Vector2 movement;

    private GameObject playerG;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

    void Start()
    {
        playerG = GameObject.Find("Player");
        player = playerG.transform;

        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy(movement);
        this.spriteRenderer.flipX = player.transform.position.x < this.transform.position.x;

        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
    }

    public void MoveEnemy(Vector2 direction)
    {
        animator.SetFloat(VerticalWrapMode, 1f);
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
