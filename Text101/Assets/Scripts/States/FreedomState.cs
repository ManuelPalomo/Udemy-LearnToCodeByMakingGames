using UnityEngine;

public class FreedomState : State {

	private TextController textController;

	public FreedomState(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You are free!\n\n" +
		"Press P to play again");

		if(Input.GetKeyDown(KeyCode.P)) {
			textController.SetState(new CellState(textController));
		}
	}
}
