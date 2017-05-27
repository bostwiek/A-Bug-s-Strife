using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour {

	public int nextLevel;


	void OnTriggerEnter2D (Collider2D col) {
		if (col.name == "Player")
		{
			NextLevel();
		}
	}

	void NextLevel() {
		Application.LoadLevel (nextLevel);
	}

}
