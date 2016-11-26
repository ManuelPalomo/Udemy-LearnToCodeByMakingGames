using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public float width = 12f;
	public float height = 8f;

	public float speed = 5f;

	private bool movingRight = true;

	public float spawnDelay = 0.5f;

	private float maximumXPosition;
	private float minimumXPosition;


	void Start() {
		float distanceBetweenCameraAndPosition = transform.position.z - Camera.main.transform.position.z;

		Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceBetweenCameraAndPosition));
		Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceBetweenCameraAndPosition));

		maximumXPosition = rightMostPosition.x;
		minimumXPosition = leftMostPosition.x;

		SpawnEnemies();
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

		if(AllMembersDead()) {
			SpawnUntilFull();
		}
	}

	private void MoveRight() {
		transform.position += new Vector3(speed * Time.deltaTime, 0);
	}

	private void MoveLeft() {
		transform.position += new Vector3(-speed * Time.deltaTime, 0);
	}


	private void SpawnEnemies() {
		foreach(Transform child in this.transform) {
			GameObject enemy = (GameObject)Instantiate(enemyPrefab, child.transform.position, Quaternion.identity);
			enemy.transform.parent = child;
		}
	}

	private void SpawnUntilFull() {
		Transform freePosition = NextFreePosition();
		if(freePosition) {
			GameObject enemy = (GameObject)Instantiate(enemyPrefab, freePosition.position, Quaternion.identity);
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition()) {
			Invoke("SpawnUntilFull", spawnDelay);
		}
	}

	private Transform NextFreePosition() {
		foreach(Transform child in this.transform) {
			if(child.childCount == 0) {
				return child;
			}
		}
		return null;
	}

	private bool AllMembersDead() {
		foreach(Transform child in this.transform) {
			if(child.childCount != 0) {
				return false;
			}
		}
		return true;
	}
}
