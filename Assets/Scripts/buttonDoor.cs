using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonDoor : MonoBehaviour {
	
	private Animator an;

	public GameObject door;
	private bool doorShut;

	void Start () {
		an = GetComponent<Animator>();
		door = GameObject.Find("doorTest");
		doorShut = true;
	}

	void OnTriggerEnter2D (Collider2D col) {
		{	
			
			an.SetBool("press", true);

			if (doorShut == true)
			{
				door.transform.Translate(0, 30f, 0);
				doorShut = false;
			}
			else
			{
				door.transform.Translate(0, -30f, 0);
				doorShut = true;
			}
		}

	}

	void OnTriggerExit2D (Collider2D col) {
		an.SetBool("press", false);

	}
}
