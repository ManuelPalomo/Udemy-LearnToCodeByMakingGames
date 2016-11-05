using UnityEngine;

public class Sheets0State : State {

	private TextController textController;

	public Sheets0State(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You lean on your bed, and see your 20 old bedsheets, they are " +
		"absolutely nasty, and reek really bad. ¿How come you didn't notice them before?\n " +
		"Press R to Return roaming your cell");

		if(Input.GetKeyDown(KeyCode.R)) {
			textController.SetState(new CellState(textController));
		} 
	}
}
