using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxRange : MonoBehaviour {

	public GameObject monkeyCanvas;

	void Start () {
		monkeyCanvas.SetActive(false);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.name == "Player")
		{
			//show NPC text
			monkeyCanvas.SetActive(true);
		}
	}
	void OnTriggerExit2D (Collider2D col) {
		if (col.name == "Player")
		{
			//hide NPC text
			monkeyCanvas.SetActive(false);
		}
	}
}
