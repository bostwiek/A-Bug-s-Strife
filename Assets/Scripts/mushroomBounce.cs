using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroomBounce : MonoBehaviour {

	public float bounceHeight;
	private Animator an;


	void Start () {
		an = GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D col) {
		{	
			if (col.GetComponent<Rigidbody2D>())
			{
				col.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, bounceHeight));
				an.SetBool("bounce", true);
			}
		}

	}

	void OnTriggerExit2D (Collider2D col) {
		
		an.SetBool("bounce", false);

	}
}
