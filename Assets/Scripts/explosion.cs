using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {


	public float exDelay = 5f;
	public float exRate = 1f;
	public float exMaxSize = 15f;
	public float exSpeed = 5f;
	public float exCurrentRadius = 0f;

	public bool exploded = false;
	CircleCollider2D exRadius;

	void Start () {
		exRadius = gameObject.GetComponent<CircleCollider2D>();
	}

	void FixedUpdate () {
		if (exploded == true)
		{
			if (exCurrentRadius < exMaxSize)
			{
				exCurrentRadius += exRate;
			}

			exRadius.radius = exCurrentRadius;
		}
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (exploded == true)
		{
			if (col.gameObject.GetComponent<Rigidbody2D>() != null)
			{
				Vector2 target = col.gameObject.transform.position;
				Vector2 bomb = gameObject.transform.position;

				Vector2 direction = 140f * (target - bomb);

				col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);
			}
		}

	}
}
