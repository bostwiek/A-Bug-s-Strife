using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFollow : MonoBehaviour {

	public GameObject Target;
	private Rigidbody2D rb;
	public Vector3 playerPos;
	private string direction;
	public bool facingRight;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		facingRight = true;
	}
	
	void FixedUpdate () {

		// xDif = Player position x - my position X
		float xDif = Target.transform.position.x - transform.position.x;

		// if we're facing Right and target is on our left OR ...
		if (xDif < 0 && facingRight || xDif > 0 && !facingRight)
		{
			Flip();
		}

		if (xDif > 0)
		{
			rb.velocity += Vector2.right;
		}
		else
		{
			rb.velocity += Vector2.left;
		}
	}

	private void Flip() {
		facingRight = !facingRight;
		Vector3 mylocalScale = transform.localScale;
		mylocalScale.x *= -1;
		transform.localScale = mylocalScale;
	}

}
