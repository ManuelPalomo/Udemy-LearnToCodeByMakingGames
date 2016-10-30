using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	private int max,min,guess;

	void Start() {
		StartGame();
	}

	private void StartGame() {
		max = 1000;
		min = 1;
		guess = 500;


		print("=========================");
		print("Welcome to number Wizard");
		print("Pick a number in your head,but don't tell me!");

		print("The highest number you can pick is " + max);
		print("The lowest number you can pick is " + min);

		print("Is the number higher or lower than " + guess + " ?");
		print("Up = higher, Down =lower, Return = equal");

		max += 1;
	
	}
	void Update() {

		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			min = guess;
			NextGuess();

		} else if(Input.GetKeyDown(KeyCode.DownArrow)) {
			max = guess;
			NextGuess();

		} else if(Input.GetKeyDown(KeyCode.Return)) {
			print("I won!");
			StartGame();
		}

	}

	private void NextGuess() {
		guess = (max + min) / 2;
		print("Higher or lower than " + guess);
	}
}
