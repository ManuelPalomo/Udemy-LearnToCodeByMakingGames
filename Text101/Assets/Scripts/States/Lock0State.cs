using UnityEngine;

public class Lock0State : State {
	private TextController textController;

	public Lock0State(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You lean on your doorlock, it's a combination lock with a few " +
		"buttons on your side, you press a few at a random order, but nothing really " +
		"happens.\n" +
		"Press R to Return roaming your cell");

		if(Input.GetKeyDown(KeyCode.R)) {
			textController.SetState(new CellState(textController));
		} 
	}
}
