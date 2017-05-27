using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mantis : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;

	public float mantisSpeed, timeToTravel, maxSpeed, absSpeed;

	private bool facingRight, attacking;
	private int turnAround, slacking;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		facingRight = false;
		slacking = 0;
		timeToTravel = 0;
		maxSpeed = 10f;
		attacking = false;
	}
	
	void FixedUpdate () {

		if (facingRight)
		{
			mantisSpeed = Mathf.Abs(mantisSpeed);
		}
		else
		{
			mantisSpeed = (Mathf.Abs(mantisSpeed)) * -1;
		}

		timeToTravel += Time.deltaTime;

		if (timeToTravel > 3)
		{

			turnAround = Random.Range(0, 2);
			if (turnAround > 0)
			{
				mantisSpeed = 0f;
				Turn();
			}
			else
			{

				slacking = Random.Range(0, 2);
				if (slacking > 0)
				{
					mantisSpeed = maxSpeed;
				} else {
					mantisSpeed = 0f;
				}				
			}

			timeToTravel = 0;

		}
		else
		{
			rb.velocity = new Vector2(mantisSpeed, rb.velocity.y);
		}

		absSpeed = Mathf.Abs(mantisSpeed);
		an.SetFloat("speed", absSpeed);

		// if mantis sees snail

		// start attack coroutine

	}

	public void Turn() {
		// cause every now and then I fall APARRRT
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
