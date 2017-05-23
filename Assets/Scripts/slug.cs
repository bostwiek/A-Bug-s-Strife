using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slug : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;

	public float slugSpeed, timeToTravel, maxSpeed, absSpeed;

	private bool facingRight;
	private int turnAround, slacking;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		facingRight = false;
		slacking = 0;
		timeToTravel = 0;
		maxSpeed = 3f;
		slugSpeed = 0f;
	}
	
	void FixedUpdate () {

		if (facingRight)
		{
			slugSpeed = Mathf.Abs(slugSpeed);
		}
		else
		{
			slugSpeed = (Mathf.Abs(slugSpeed)) * -1;
		}

		timeToTravel += Time.deltaTime;

		if (timeToTravel > 3)
		{

			turnAround = Random.Range(0, 2);
			if (turnAround > 0)
			{
				slugSpeed = 0f;
				Turn();
			}
			else
			{

				slacking = Random.Range(0, 2);
				if (slacking > 0)
				{
					slugSpeed = maxSpeed;
				} else {
					slugSpeed = 0f;
				}				
			}

			timeToTravel = 0;

		}
		else
		{
			rb.velocity = new Vector2(slugSpeed, rb.velocity.y);
		}

		absSpeed = Mathf.Abs(slugSpeed);
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
