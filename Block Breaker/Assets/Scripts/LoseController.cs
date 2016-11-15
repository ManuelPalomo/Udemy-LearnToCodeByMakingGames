using UnityEngine;
using System.Collections;

public class LoseController : MonoBehaviour {

	private  LevelManager levelManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D(Collider2D trigger) {
		levelManager.LoadLevel("Lose");
	}

}
