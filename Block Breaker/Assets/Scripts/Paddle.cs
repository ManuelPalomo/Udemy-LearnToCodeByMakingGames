using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	private const float MIN_SCREEN_POS = 0.5f;
	private const float MAX_SCREEN_POS = 15.5f;


	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	void Update() {
		if(!autoPlay) {
			MovePaddleUsingMouse();
		} else {
			AutoPlay();
		}
	}

	private void MovePaddleUsingMouse() {
		float mousePositionInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, MIN_SCREEN_POS, MAX_SCREEN_POS);
		Vector3 newPosition = new Vector3(mousePositionInBlocks, this.transform.position.y, 0);
		this.transform.position = newPosition;
	}

	private void AutoPlay() {
		float ballPosition = ball.transform.position.x;
		Vector3 newPaddlePos = new Vector3(Mathf.Clamp(ballPosition,0.5f,15.5f),this.transform.position.y,0f);
		this.transform.position = newPaddlePos;

	}
}
