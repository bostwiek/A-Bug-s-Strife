using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	private Transform target;

	Camera camera;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;
		camera = GetComponent<Camera>();
	}


	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (target.position.x, target.position.y, transform.position.z);
	}
}
