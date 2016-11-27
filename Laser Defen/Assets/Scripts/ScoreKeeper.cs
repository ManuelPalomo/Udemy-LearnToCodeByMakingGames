using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	private Text text;
	public static int score;


	public void Start() {
		text = this.GetComponent<Text>();
		Reset();
	}

	public void Score(int points) {
		score += points;
		text.text = score.ToString();
	}

	public static void Reset() {
		score = 0;
	}
}
