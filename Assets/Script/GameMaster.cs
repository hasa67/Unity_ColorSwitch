using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GoToGameScene()
    {
		SceneManager.LoadScene(1);
    }

	public void GoToMainScene()
    {
		SceneManager.LoadScene(0);
	}

	public void RestartGameScene()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
