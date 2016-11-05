using UnityEngine;

public class Lock1State : State {

	private TextController textController;

	public Lock1State(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You put your mirror between the bars on\n" +
		"door, and you can see some fingerprints on the buttons\n" +
		"on the other side. You try to press them in order and the\n" +
		"door suddenly opens\n" +
		"Press O to Open the door, or R to Return to your cell");

		if(Input.GetKeyDown(KeyCode.R)) {
			textController.SetState(new CellMirrorState(textController));
		} else if(Input.GetKeyDown(KeyCode.O)) {
			textController.SetState(new FreedomState(textController));
		}
	}
}
