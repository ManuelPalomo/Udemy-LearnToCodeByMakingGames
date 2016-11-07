using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	private int max,min,guess,maxGuessesAllowed;

	public Text text;

	void Start() {
		StartGame();
	}

	private void StartGame() {
		max = 1000;
		min = 1;
		maxGuessesAllowed = 10;
		NextGuess();
	}

	public void GuessHigher() {
		min = guess;
		NextGuess();
	}

	public void GuessLower() {
		max = guess;
		NextGuess();
	}

	private void NextGuess() {
		guess = Random.Range(min, max + 1);
		text.text = guess.ToString();
		maxGuessesAllowed--;
		if(maxGuessesAllowed <= 0) {
			SceneManager.LoadScene("Win");
		}
	}
}
