using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private State currentState;

	void Start() {
		currentState = new CellState(this);
	}


	void Update() {
		currentState.Handle();
	}

	public void SetText(string newText) {
		text.text = newText;
	}

	public void SetState(State state) {
		this.currentState = state;
	}

}
