using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	void Start() {
		Text text = GetComponent<Text>();
		text.text = ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();
	}

}
