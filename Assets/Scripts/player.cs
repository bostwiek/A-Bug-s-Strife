using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;
	public Transform sightStart, sightEnd;
	public Transform[] feet = new Transform[3];
	public LayerMask ground;
	public GameObject bloodSpawner;
	private Vector3 spawn;

	public float movementSpeed, jumpForce, climbSpeed, feetRadius;
	public bool facingRight, onLadder, canControl;
	private bool spotted, isGrounded;

	// ladder stuff
	private float climbVelocity, gravityStore;

	void Start () {
		spawn = transform.position;
		facingRight = true;
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		spotted = false;
		canControl = true;
		gravityStore = rb.gravityScale;
	}
	
	void FixedUpdate () {
		if (canControl)
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			handleInput();
			handleMovement(horizontal, vertical);
		}

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "mine"){
			StartCoroutine(playerDies());
		}
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
		if (Input.GetKeyDown(KeyCode.Space)) {

			for (int x = 0; x < feet.Length; ++x)
			{
				isGrounded = Physics2D.OverlapCircle(feet[x].transform.position, feetRadius, ground);
				if (isGrounded)
				{
					rb.AddForce(new Vector2(0, jumpForce));
					// an.SetBool ("jump", true);
					break;
				}
			}
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

	IEnumerator playerDies() {

		an.SetBool("dead", true);
		canControl = false;
		bloodSpawner.GetComponent<bloodSpawn>().spawnBlood();
		yield return new WaitForSeconds(2.0f);

		an.SetBool("dead", false);
		transform.position = spawn;
		transform.rotation = Quaternion.identity;
		canControl = true;

	}
}
