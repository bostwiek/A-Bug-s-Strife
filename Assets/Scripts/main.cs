using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {

		// layer NPC and Player collisions are ignored
		Physics2D.IgnoreLayerCollision(8, 9);

	}
}
