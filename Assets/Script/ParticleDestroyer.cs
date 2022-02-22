using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour {

	public ParticleSystem ps;
	float totalTime;

	private AudioSource dieSound;

    [System.Obsolete]
    void Start () {
		totalTime = ps.duration + ps.startLifetime;
		dieSound = GetComponent<AudioSource>();
		dieSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, totalTime);
	}
}
