using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private State currentState;

	void Start() {
		currentState = State.cell;
	}


	void Update() {
		switch(currentState) {
			case(State.cell):
				StateCell();
				break;
			case(State.sheets0):
				Sheets0();
				break;
			case(State.lock0):
				Lock0();
				break;
			case(State.mirror):
				Mirror();
				break;
			case(State.cellMirror):
				CellMirror();
				break;
			case(State.sheets1):
				Sheets1();
				break;
			case(State.lock1):
				Lock1();
				break;
			case(State.freedom):
				Freedom();
				break;
		}
	}

	void StateCell() {
		text.text = "You wake up in your old prison cell, with a few sunrays hitting on your " +
		"face and gladly warming it up,'I have to escape this prison today'-You " +
		"say to yourself.\n" +
		"You look around: There are your old and dirty bedsheets, a mirror on the " +
		"wall, and in front of you there's the door, obviusly closed.\n" +
		"Press S to view the Sheets, M to view the mirror, and L to view the doorlock";

		if(Input.GetKeyDown(KeyCode.S)) {
			currentState = State.sheets0;
		} else if(Input.GetKeyDown(KeyCode.M)) {
			currentState = State.mirror;
		} else if(Input.GetKeyDown(KeyCode.L)) {
			currentState = State.lock0;
		}
	}

	void Sheets0() {
		text.text = "You lean on your bed, and see your 20 old bedsheets, they are " +
		"absolutely nasty, and reek really bad. ¿How come you didn't notice them before?\n " +
		"Press R to Return roaming your cell";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = State.cell;
		} 
	}

	void Lock0() {
		text.text = "You lean on your doorlock, it's a combination lock with a few " +
		"buttons on your side, you press a few at a random order, but nothing really " +
		"happens.\n" +
		"Press R to Return roaming your cell";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = State.cell;
		} 
	}

	void Mirror() {
		text.text = "You see yourself reflected on the mirror, you are ugly as a sin.\n" +
		"The mirror seems loose, maybe with a bit of force it can come out of the wall.\n" +
		"Press T o Take the mirror or R to Return roaming your cell";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = State.cell;
		} else if(Input.GetKeyDown(KeyCode.T)) {
			currentState = State.cellMirror;
		}

	}

	void CellMirror() {
		text.text = "You are still on your cell, holding the mirror\n" +
		"There are some dirty sheets on your bed, a spot where the\n" +
		"mirror used to be, and the door, still locked\n" +
		"Press S to view the Sheets, or L to view the Lock";

		if(Input.GetKeyDown(KeyCode.S)) {
			currentState = State.sheets1;
		} else if(Input.GetKeyDown(KeyCode.L)) {
			currentState = State.lock1;
		}

	}

	void Sheets1() {
		text.text = "You look the sheets trough the reflection\n" +
		"on your mirror, they look exactly the same: crappy\n" +
		"Press R to return roaming to your cell";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = State.cellMirror;
		}
	}

	void Lock1() {
		text.text = "You put your mirror between the bars on\n" +
		"door, and you can see some fingerprints on the buttons\n" +
		"on the other side. You try to press them in order and the\n" +
		"door suddenly opens\n" +
		"Press O to Open the door, or R to Return to your cell";

		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = State.cellMirror;
		} else if(Input.GetKeyDown(KeyCode.O)) {
			currentState = State.freedom;
		}
	}

	void Freedom() {
		text.text = "You are free!\n\n" +
		"Press P to play again";

		if(Input.GetKeyDown(KeyCode.P)) {
			currentState = State.cell;
		}
	}


}
