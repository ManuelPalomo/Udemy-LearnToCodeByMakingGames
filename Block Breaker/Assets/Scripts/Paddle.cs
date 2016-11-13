using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	private const float MIN_SCREEN_POS = 0.5f;
	private const float MAX_SCREEN_POS = 15.5f;


	

	void Start() {
	
	}

	void Update() {
		MovePaddleUsingMouse();
	}

	private void MovePaddleUsingMouse() {
		float mousePositionInBlocks = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, MIN_SCREEN_POS, MAX_SCREEN_POS);
		Vector3 newPosition = new Vector3(mousePositionInBlocks, this.transform.position.y, 0);
		this.transform.position = newPosition;
	}
}
