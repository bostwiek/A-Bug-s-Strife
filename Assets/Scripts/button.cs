using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour {
	
	private Animator an;

	public GameObject obj;

	void Start () {
		an = GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D col) {
		{
			an.SetBool("press", true);
		}

	}

	void OnTriggerExit2D (Collider2D col) 
	{
		an.SetBool("press", false);
	}
}
