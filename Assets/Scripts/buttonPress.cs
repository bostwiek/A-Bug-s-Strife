using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour {
	
	private Animator an;

	public GameObject explosion;
	public Animator explosionAn;

	void Start () {
		an = GetComponent<Animator>();
		explosionAn = explosion.GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D col) {
		{	
			an.SetBool("press", true);
			explosionAn.SetBool("explosion", true);

		}

	}

	void OnTriggerExit2D (Collider2D col) {
		
		an.SetBool("press", false);
		explosionAn.SetBool("explosion", false);

	}
}
