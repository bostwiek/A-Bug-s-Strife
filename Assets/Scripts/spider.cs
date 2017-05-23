using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spider : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;

	public float spiderSpeed, timeToTravel, maxSpeed, absSpeed;

	private bool facingRight, pissedOff;
	private int turnAround, slacking;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		facingRight = false;
		slacking = 0;
		timeToTravel = 0;
		maxSpeed = 10f;
		pissedOff = false;
	}
	
	void FixedUpdate () {

		if (facingRight)
		{
			spiderSpeed = Mathf.Abs(spiderSpeed);
		}
		else
		{
			spiderSpeed = (Mathf.Abs(spiderSpeed)) * -1;
		}

		timeToTravel += Time.deltaTime;

		if (timeToTravel > 3)
		{

			turnAround = Random.Range(0, 2);
			if (turnAround > 0)
			{
				spiderSpeed = 0f;
				Turn();
			}
			else
			{

				slacking = Random.Range(0, 2);
				if (slacking > 0)
				{
					spiderSpeed = maxSpeed;
				} else {
					spiderSpeed = 0f;
				}				
			}

			timeToTravel = 0;

		}
		else
		{
			rb.velocity = new Vector2(spiderSpeed, rb.velocity.y);
		}

		absSpeed = Mathf.Abs(spiderSpeed);
		an.SetFloat("speed", absSpeed);
		an.SetBool("pissedoff", pissedOff);

	}

	public void Turn() {
		// cause every now and then I fall APARRRT
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void searchPlayer() {

		// raycast search Player

		if (pissedOff)
		{
			pissedOff = true;
		}
		else
		{
			pissedOff = false;
		}
	}
}
