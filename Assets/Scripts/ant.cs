using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;

	public float antSpeed, timeToTravel, maxSpeed, absSpeed;

	private bool facingRight;
	private int turnAround, slacking;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		facingRight = false;
		slacking = 0;
		timeToTravel = 0;
		maxSpeed = 10f;
	}
	
	void FixedUpdate () {

		if (facingRight)
		{
			antSpeed = Mathf.Abs(antSpeed);
		}
		else
		{
			antSpeed = (Mathf.Abs(antSpeed)) * -1;
		}

		timeToTravel += Time.deltaTime;

		if (timeToTravel > 3)
		{

			turnAround = Random.Range(0, 2);
			if (turnAround > 0)
			{
				antSpeed = 0f;
				Turn();
			}
			else
			{

				slacking = Random.Range(0, 2);
				if (slacking > 0)
				{
					antSpeed = maxSpeed;
				} else {
					antSpeed = 0f;
				}				
			}

			timeToTravel = 0;

		}
		else
		{
			rb.velocity = new Vector2(antSpeed, rb.velocity.y);
		}

		absSpeed = Mathf.Abs(antSpeed);
		an.SetFloat("speed", absSpeed);

	}

	public void Turn() {
		// cause every now and then I fall APARRRT
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
