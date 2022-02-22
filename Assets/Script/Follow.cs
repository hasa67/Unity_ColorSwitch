using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Follow : MonoBehaviour {

	public Transform player;
	public GameObject restartPanel;


	void Start () {
		
	}
	
	void Update () {

		if(player != null)
        {
			if(player.position.y > transform.position.y)
            {
				transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
			}
        }
        else
        {
			Invoke("Died", 2f);
        }
	}

	void Died()
	{
		restartPanel.SetActive(true);
	}
}
