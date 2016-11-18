using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private Vector3 paddleToBallVector;
	private Rigidbody2D rigidBody;
	private AudioSource audioComponent;
	private bool hasGameStarted;

	void Start() {
		audioComponent = this.GetComponent<AudioSource>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = GetPaddleToBallVector();
		rigidBody = this.GetComponent<Rigidbody2D>();
		hasGameStarted = false;
	
	}

	void Update() {
		if(!hasGameStarted) {
			this.transform.position = MantainPaddleToBallDistance();
		
			if(Input.GetMouseButtonDown(0)) {
				hasGameStarted = true;
				rigidBody.velocity = new Vector2(2f, 10f);
			}
		}
	
	}

	private Vector3 GetPaddleToBallVector() {
		return this.transform.position - paddle.transform.position;
	}

	private Vector3 MantainPaddleToBallDistance() {
		return paddle.transform.position + paddleToBallVector;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		rigidBody.velocity += tweak;
		if(hasGameStarted) {
			audioComponent.Play();
		}
	}
}
