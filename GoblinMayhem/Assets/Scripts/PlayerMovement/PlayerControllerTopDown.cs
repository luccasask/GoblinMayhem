using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class PlayerControllerTopDown : MonoBehaviour //Premade Player controller. Flips the sprite when walking in certain directions.
{
	[Range(0, 1f)] [SerializeField] 
	private float m_MovementSmoothing = .05f;  // How much to smooth out the movement

	private Rigidbody2D rb;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	public Animator anim;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{

	}

	public void Move(float moveX, float moveY)
	{

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector3(moveX * 10f, moveY * 10f, rb.velocity.y);

		// And then smoothing it out and applying it to the character
		rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		//Start run animation when moving
		anim.SetFloat("Speed", rb.velocity.sqrMagnitude);
		anim.SetFloat("Vertical", moveY * 10f);

		// If the input is moving the player right and the player is facing left...
		if (moveX > 0 && !m_FacingRight)
		{
			// ... flip the player.
			Flip();
		}

		// Otherwise if the input is moving the player left and the player is facing right...
		else if (moveX < 0 && m_FacingRight)
		{
			// ... flip the player.
			Flip();
		}
	}

	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
