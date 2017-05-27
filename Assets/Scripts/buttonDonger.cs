using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDonger : MonoBehaviour {
	
	private Animator an;

	public GameObject door;
	public Rigidbody2D doorRb;

	public float dongerSpeed, dongerMaxSpeed;

	private bool isAwake;

	void Start () {
		an = GetComponent<Animator>();
		door = GameObject.Find("donger");
		doorRb = door.GetComponent<Rigidbody2D>();
		isAwake = false;
		dongerSpeed = 0f;
	}

	void FixedUpdate() {
		doorRb.velocity = new Vector2(doorRb.velocity.x, dongerSpeed);
	}

	void OnTriggerEnter2D (Collider2D col) {
		{	
			if (isAwake == false)
			{
				dongerSpeed = dongerMaxSpeed;
				isAwake = true;
			}
			else
			{
				dongerSpeed *= -1f;
			}
			an.SetBool("press", true);
		}

	}

	void OnTriggerExit2D (Collider2D col) {
		an.SetBool("press", false);
	}
}
