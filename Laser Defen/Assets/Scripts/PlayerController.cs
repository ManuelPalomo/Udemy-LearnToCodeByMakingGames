using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public int speed;

	private float maximumXPosition;
	private float minimumXPosition;

	void Start() {
		float spritePadding = 1f;
		float distanceBetweenCameraAndPlayer = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceBetweenCameraAndPlayer));
		Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceBetweenCameraAndPlayer));

		this.minimumXPosition = leftMostPosition.x + spritePadding;
		this.maximumXPosition = rightMostPosition.x - spritePadding;
	}


	void Update() {
		HandleMovement();	
	}

	private void HandleMovement() {
		if(Input.GetKey(KeyCode.RightArrow)) {
			MoveRight();

		} else if(Input.GetKey(KeyCode.LeftArrow)) {
			MoveLeft();
		}
		RestrictMovement();
	}

	private void MoveRight() {
		this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
	}

	private void MoveLeft() {
		this.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
	}

	private void RestrictMovement() {
		float newX = Mathf.Clamp(this.transform.position.x, minimumXPosition, maximumXPosition);
		this.transform.position = new Vector2(newX, this.transform.position.y);
	}


}
