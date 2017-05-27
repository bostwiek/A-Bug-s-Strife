using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodSpawn : MonoBehaviour {

	public GameObject bloodPrefab;
	public GameObject[] Clone;
	public Transform bloodSpawner;
	public player player;
	public float projectileSpeedX, projectileSpeedY, bloodExpiration;
	public bool playerDead;

	public float bloodTime, speedX, speedY;
	public int bloodCount;

	void Start () {
		bloodSpawner = GetComponent<Transform>();
		bloodCount = 1;
		playerDead = false;
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.Q))
		{
			spawnBlood2();
		}

	}

	public void spawnBlood() {

		GameObject Clone, Clone2, Clone3, Clone4, Clone5;

		Clone = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone2 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone3 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone4 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone5 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;

		speedX = 1f;

		Clone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone3.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone4.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone5.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);

		GameObject.Destroy(Clone, 12.0f);
	
	}

	public void spawnBlood2() {
		
		int loops = 7;

		for (int i = 0; i < loops; i++) {
			GameObject clone = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
			Clone [i] = clone;
			clone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		}

	}
}
