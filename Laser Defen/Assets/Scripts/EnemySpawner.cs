using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public float width = 12f;
	public float height = 8f;

	public float speed = 5f;

	private bool movingRight = true;

	private float maximumXPosition;
	private float minimumXPosition;


	void Start() {
		float distanceBetweenCameraAndPosition = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceBetweenCameraAndPosition));
		Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceBetweenCameraAndPosition));

		maximumXPosition = rightMostPosition.x;
		minimumXPosition = leftMostPosition.x;

		foreach(Transform child in this.transform) {
			GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
			enemy.transform.parent = child;
		}
	}

	public void OnDrawGizmos() {
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
	}

	void Update() {
		if(movingRight) {
			MoveRight();
		} else {
			MoveLeft();
		}

		float leftEdgeFormation = transform.position.x - (width / 2);
		float rightEdgeFormation = transform.position.x + (width / 2);
		if(leftEdgeFormation < minimumXPosition) { 
			movingRight = true;
		} else if(rightEdgeFormation > maximumXPosition) {
			movingRight = false;
		}
	}

	private void MoveRight() {
		transform.position += new Vector3(speed * Time.deltaTime, 0);
	}

	private void MoveLeft() {
		transform.position += new Vector3(-speed * Time.deltaTime, 0);
	}
}
