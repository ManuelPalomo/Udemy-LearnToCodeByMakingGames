using UnityEngine;

public class CellState : State {
	private TextController textController;

	public CellState(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You wake up in your old prison cell, with a few sunrays hitting on your " +
		"face and gladly warming it up,'I have to escape this prison today'-You " +
		"say to yourself.\n" +
		"You look around: There are your old and dirty bedsheets, a mirror on the " +
		"wall, and in front of you there's the door, obviusly closed.\n" +
		"Press S to view the Sheets, M to view the mirror, and L to view the doorlock");

		if(Input.GetKeyDown(KeyCode.S)) {
			textController.SetState(new Sheets0State(textController));
		} else if(Input.GetKeyDown(KeyCode.M)) {
			textController.SetState(new MirrorState(textController));
		} else if(Input.GetKeyDown(KeyCode.L)) {
			textController.SetState(new Lock0State(textController));
		}
	}
}
