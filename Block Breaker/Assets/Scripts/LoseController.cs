using UnityEngine;
using System.Collections;

public class LoseController : MonoBehaviour {

	public LevelManager levelManager;

	void OnTriggerEnter2D(Collider2D trigger) {
		levelManager.LoadLevel("Win");
	}

	void OnCollisionEnter2D(Collision2D collision) {
		print("Collision");
	}
}
