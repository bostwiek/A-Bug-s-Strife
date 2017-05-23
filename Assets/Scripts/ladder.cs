using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour {

	private player thePlayer;

	void Start () {

		// reads other scripts as classes called above
		// allows player class to be referenced from here
		thePlayer = FindObjectOfType<player>();
		
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.name == "Player")
		{
			thePlayer.onLadder = true;
		}
	}
	void OnTriggerExit2D (Collider2D col) {
		if (col.name == "Player")
		{
			thePlayer.onLadder = false;
		}
	}
}
