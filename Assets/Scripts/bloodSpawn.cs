using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloodSpawn : MonoBehaviour {

	public GameObject bloodPrefab;
	private Transform bloodSpawner;
	public player player;
	public float projectileSpeedX, projectileSpeedY, bloodExpiration;
	public bool playerDead;

	private float bloodTime, speedX, speedY;
	private int bloodCount;

	void Start () {
		bloodSpawner = GetComponent<Transform>();
		bloodCount = 1;
		playerDead = false;
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.Q))
		{
			spawnBlood();
		}

	}

	public void spawnBlood() {

		GameObject Clone, Clone2, Clone3, Clone4, Clone5, Clone6, Clone7, Clone8, Clone9;

		Clone = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone2 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone3 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone4 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone5 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone6 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone7 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone8 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;
		Clone9 = (Instantiate(bloodPrefab, bloodSpawner.transform.position, bloodSpawner.transform.rotation)) as GameObject;

		speedX = 1f;

		Clone.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone2.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone3.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone4.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone5.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone6.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone7.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone8.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);
		Clone9.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (Random.Range(-20, 20), Random.Range(0, 40)), ForceMode2D.Impulse);

		GameObject.Destroy(Clone, 12.0f);
	
	}

}
