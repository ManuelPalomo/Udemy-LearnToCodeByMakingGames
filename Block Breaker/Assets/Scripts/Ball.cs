using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private Paddle paddle;

	private Vector3 paddleToBallVector;
	private Rigidbody2D rigidBody;
	private bool hasGameStarted;

	void Start() {
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
}
