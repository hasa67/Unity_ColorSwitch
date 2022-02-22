using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

	public Transform mainCamera;

	void Start () {

	}
	
	void Update () {
		transform.position = new Vector3(transform.position.x, mainCamera.position.y - 10f, transform.position.z);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Destroy(collision.gameObject);
	}

}
