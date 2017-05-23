using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snail : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;

	public float snailSpeed, timeToTravel, maxSpeed;

	private bool facingRight;
	private int turnAround, slacking;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		facingRight = false;
		slacking = 0;
		timeToTravel = 0;
		maxSpeed = 3f;
	}
	
	void FixedUpdate () {

		if (facingRight)
		{
			snailSpeed = Mathf.Abs(snailSpeed);
		}
		else
		{
			snailSpeed = (Mathf.Abs(snailSpeed)) * -1;
		}

		timeToTravel += Time.deltaTime;

		if (timeToTravel > 3)
		{

			turnAround = Random.Range(0, 2);
			if (turnAround > 0)
			{
				Turn();
			}

			slacking = Random.Range(0, 2);
			if (slacking > 0)
			{
				snailSpeed = maxSpeed;
			} else {
				snailSpeed = 0f;
			}

			timeToTravel = 0;
		}
		else
		{
			rb.velocity = new Vector2(snailSpeed, rb.velocity.y);
		}

	}

	public void Turn() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
