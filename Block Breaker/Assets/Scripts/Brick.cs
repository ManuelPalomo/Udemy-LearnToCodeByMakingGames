using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	private int timesHit;

	private LevelManager levelManager;

	void Start() {
		this.timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void Update() {

	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		timesHit++;
		if(timesHit >= maxHits) {
			Destroy(gameObject);
		}
	}


}
