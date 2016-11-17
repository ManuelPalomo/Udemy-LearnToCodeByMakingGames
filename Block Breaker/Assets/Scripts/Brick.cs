using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;

	public Sprite[] hitSprites;

	private int maxHits;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable;

	void Start() {
		isBreakable = (this.tag == "Breakable");
		if(isBreakable) {
			breakableCount++;
		}
		this.timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void Update() {

	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if(isBreakable) {
			HandleHit();
		}
	}

	public void HandleHit() {
		int maxHits = hitSprites.Length + 1;
		timesHit++;
		if(timesHit >= maxHits) {
			Destroy(gameObject);
			breakableCount--;
			levelManager.BrickDestroyed();
		} else {
			LoadSprites();
		}
	}

	public void LoadSprites() {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}

}
