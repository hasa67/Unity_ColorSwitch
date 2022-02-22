using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float jumpForce = 3f;
	public Rigidbody2D circle;

	private int randomColor;

	public Color[] color;
	public SpriteRenderer sr;

	public int score = 0;
	public Text scoreText;

	public GameObject scored;
	public GameObject colorChanger;
	public GameObject[] obstacles;
	private float[] distance = { 3f, 4f, 2f, 4f, 4f };
	private List<int> obstacleOrder = new List<int>();
	private List<float> obstacleDistance = new List<float>();

	public GameObject dieEffect;

	private AudioSource[] sounds;
	private AudioSource jumpSound;
	private AudioSource coinSound;
	private AudioSource backMusic;

	void Start () {
		ColorChanger();
		sounds = GetComponents<AudioSource>();
		jumpSound = sounds[0];
		coinSound = sounds[1];
		backMusic = sounds[2];

		backMusic.Play();

		int initialY = 2;

		Instantiate(obstacles[0], new Vector2(0, initialY), transform.rotation);
		Instantiate(scored, new Vector2(0, initialY), transform.rotation);
		Instantiate(colorChanger, new Vector2(0, initialY + distance[0]), transform.rotation);

		Instantiate(obstacles[0], new Vector2(0, initialY + distance[0]*2), transform.rotation);
		Instantiate(scored, new Vector2(0, initialY + distance[0] * 2), transform.rotation);
		Instantiate(colorChanger, new Vector2(0, initialY + distance[0] * 3), transform.rotation);


		obstacleOrder.Add(0);
		obstacleDistance.Add(distance[0]);

		obstacleOrder.Add(0);
		obstacleDistance.Add(distance[0]);
	}
	
	void Update () {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0) ||
			(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
			circle.velocity = Vector2.up * jumpForce;
			jumpSound.Play();
        }

		scoreText.text = score.ToString();
	}

	private void OnTriggerEnter2D(Collider2D collision)
    {
		if(collision.tag == "ColorChanger")
        {
			ColorChanger();
			Destroy(collision.gameObject);
			coinSound.Play();
			return;
        }

		if(collision.tag == "Scored")
        {
			score++;
			Destroy(collision.gameObject);
			CreateRandomObstacle();
			return;
        }

		if(collision.tag != randomColor.ToString())
        {
			Instantiate(dieEffect, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
    }

	void ColorChanger()
    {
		randomColor = Random.Range(0, 4);
		sr.color = color[randomColor];
	}

	void CreateRandomObstacle()
    {
		int rand = Random.Range(0, distance.Length);
		obstacleOrder.Add(rand);
		int end = obstacleOrder.Count-1;

		if(obstacleOrder[end] == 0)
        {
			obstacleDistance.Add(distance[0]);
        }
        else
        {
			obstacleDistance.Add(distance[1]);
		}

		float dist = obstacleDistance[end] + obstacleDistance[end - 1] * 2 + obstacleDistance[end - 2];

		Instantiate(obstacles[obstacleOrder[end]], new Vector2(transform.position.x, transform.position.y + dist), transform.rotation);
		Instantiate(scored, new Vector2(transform.position.x, transform.position.y + dist), transform.rotation);
		Instantiate(colorChanger, new Vector2(transform.position.x, transform.position.y + dist + obstacleDistance[end]), transform.rotation);
	}
}
