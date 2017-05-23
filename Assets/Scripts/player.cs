using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;
	public Transform sightStart, sightEnd;

	public float movementSpeed, jumpForce, climbSpeed;
	public bool facingRight, onLadder;
	private bool spotted;

	// ladder stuff
	private float climbVelocity, gravityStore;

	void Start () {
		facingRight = true;
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		spotted = false;
		gravityStore = rb.gravityScale;
	}
	
	void FixedUpdate () {

		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		handleInput();

		handleMovement(horizontal, vertical);

	}

	private void Flip(float horizontal) {

		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 mylocalScale = transform.localScale;
			mylocalScale.x *= -1;

			transform.localScale = mylocalScale;
		}
	}

	private void handleMovement(float horizontal, float vertical) {
		rb.velocity = new Vector2(horizontal * movementSpeed, rb.velocity.y);
		Flip(horizontal);
		an.SetFloat("speed", Mathf.Abs(horizontal));
	}

	private void handleInput() {
		if (Input.GetKeyDown(KeyCode.E))
		{
			// check sightStart to sightEnd to see if any NPCs are in range
			lookAhead();
			if (spotted == true)
			{
				Debug.Log("NPC Spotted!");
			}
		}
		if (Input.GetKeyDown(KeyCode.Space)) {
			rb.AddForce(new Vector2(0, jumpForce));
			// an.SetBool ("jump", true);
		}

		// ladder stuff
		if (onLadder) {
			rb.gravityScale = 0f;
			climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
			rb.velocity = new Vector2(rb.velocity.x, climbVelocity);
		}
		if (!onLadder)
		{
			rb.gravityScale = gravityStore;
		}
	}

	private void lookAhead() {
		spotted = Physics2D.Linecast (sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("NPC"));
	}
}
