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

    private bool facingDown;  // For determining which way the player is currently facing.
    public float goblinsTurnRadius = 0.1f;

    private int healthTest = 3;

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

        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
        animator.SetFloat("Speed", 1f);

        //if goblin position is within a certain area/position
        if (this.transform.position.y > (player.position.y - goblinsTurnRadius) && this.transform.position.y < (player.position.y + goblinsTurnRadius))
        {
            animator.SetFloat("Vertical", 0f);  //Goblin shows face
        }
        //if enemy is running upwards 
        else if (movement.y > 0)
        {
            animator.SetFloat("Vertical", 1f); //Goblin shows back
        }
        //if enemy is running downwards
        else if (movement.y < 0)
        {
            animator.SetFloat("Vertical", 0f);  //Goblin shows face
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "bullet")
        {
            healthTest = -1;
            if (healthTest <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
