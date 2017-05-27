using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textMove : MonoBehaviour {

	public float yPos, timeLoop, speedX;

	void Start () {
		timeLoop = 0f;
		speedX = 0.5f;
	}
	
	void Update () {

		timeLoop += Time.deltaTime;

		if (timeLoop > 8)
		{
			timeLoop = 0;
			speedX *= -1;
		}
		else
		{
			transform.Translate(speedX, 0, 0);
			transform.Rotate(Vector3.back * Time.deltaTime, Space.World);
		}
		
	}
}
