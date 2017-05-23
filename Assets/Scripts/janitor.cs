using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class janitor : MonoBehaviour {

	[SerializeField]
	private float janitorSpeed;

	private Rigidbody2D janitorRigidbody;
	private Animator janitorAnimator;
	public Transform sightStart, sightEnd;

	private Vector3 janitorSpawn;

	private bool facingRight, foundDirty, isCleaning, searching;
	private int turnAround, clean;

	[SerializeField]
	private float distance, timeToTravel;

	void Start () {
		janitorRigidbody = GetComponent<Rigidbody2D>();
		janitorAnimator = GetComponent<Animator> ();
		janitorSpawn = transform.position;
		facingRight = true;
		foundDirty = false;
		searching = false;
		timeToTravel = 0;
		distance = Random.Range(3f, 6f);
	}

	void FixedUpdate () {
		
		if (facingRight) {
			janitorSpeed = Mathf.Abs (janitorSpeed);
		} else {
			janitorSpeed = (Mathf.Abs (janitorSpeed)) * -1;
		}
		timeToTravel += Time.deltaTime;

		if (timeToTravel <= distance) {
			
			// stop all the things

			janitorAnimator.SetFloat ("speed", 0);
			janitorRigidbody.velocity = new Vector2 (0, janitorRigidbody.velocity.y);
			if (clean == 1) {
				janitorAnimator.SetBool ("sweep", true);
			}

		} else {
			janitorAnimator.SetBool ("sweep", false);
			janitorRigidbody.velocity = new Vector2 (janitorSpeed, janitorRigidbody.velocity.y);
			janitorAnimator.SetFloat ("speed", Mathf.Abs (janitorSpeed));

			if (timeToTravel > (distance * 2)) {
				
				timeToTravel = 0;
				turnAround = Random.Range (0, 2);

				// cause every now and then I fall apart...
				if (turnAround == 0) {
					facingRight = !facingRight;
					Vector3 theScale = transform.localScale;
					theScale.x *= -1;
					transform.localScale = theScale;
				}

				// determine whether or not janitor feels like cleaning
				clean = Random.Range (0, 2);
			}
		}


		// checks for poop/pee

		//otherwise rolls a random number of steps in a random direction


		// executes, all the while checking for poop pee
		// StartCoroutine (patrol (distance, timeToTravel));

		// this sends value to the animator

		// when reaching destination, stop for ~3-5 seconds, and re-roll

	}

	IEnumerator patrol(float time, float distance ) {

		wait ();
		yield return new WaitForSeconds (5);
		walk ();

	}

	void wait() {
		janitorRigidbody.velocity = new Vector2 (0, janitorRigidbody.velocity.y);
	}

	void walk() {
		janitorRigidbody.velocity = new Vector2 (3, janitorRigidbody.velocity.y);
	}

	void breakitDown() {
	}
}
