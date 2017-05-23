using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkey : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator an;
	public Vector3 playerPos;
	public GameObject Target, monkeyCanvas;


	public bool facingRight, spotted;

	void Start () {
		facingRight = true;
		spotted = true;
		rb = GetComponent<Rigidbody2D>();
		an = GetComponent<Animator>();
		// monkeyCanvas = GameObject.Find("monkeyCanvas");
		// Supposedly this works to Find GameObjects
	}
	
	void FixedUpdate () {

		// if player interacts
		if (spotted == true) {

			// xDif = Player position x - my position X
			float xDif = Target.transform.position.x - transform.position.x;

			// if we're facing Right and target is on our left OR ...
			if (xDif < 0 && facingRight || xDif > 0 && !facingRight)
			{
				Flip();
			}
		}

	}

	private void Flip() {
		facingRight = !facingRight;
		Vector3 mylocalScale = transform.localScale;
		mylocalScale.x *= -1;
		transform.localScale = mylocalScale;

		Vector3 monkeyCanvasScale = monkeyCanvas.transform.localScale;
		monkeyCanvasScale.x *= -1;
		monkeyCanvas.transform.localScale = monkeyCanvasScale;
	}
}
