using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;

	void Start() {
		GameObject enemy = (GameObject)Instantiate(enemyPrefab, new Vector3(0, 0, 0), Quaternion.identity);
		enemy.transform.parent = this.transform;

	}

	void Update() {
	
	}
}
