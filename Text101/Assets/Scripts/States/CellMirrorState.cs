using UnityEngine;

public class CellMirrorState : State {

	private TextController textController;

	public CellMirrorState(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You are still on your cell, holding the mirror\n" +
		"There are some dirty sheets on your bed, a spot where the\n" +
		"mirror used to be, and the door, still locked\n" +
		"Press S to view the Sheets, or L to view the Lock");

		if(Input.GetKeyDown(KeyCode.S)) {
			textController.SetState(new Sheets1State(textController));
		} else if(Input.GetKeyDown(KeyCode.L)) {
			textController.SetState(new Lock1State(textController));
		}
	}
}
