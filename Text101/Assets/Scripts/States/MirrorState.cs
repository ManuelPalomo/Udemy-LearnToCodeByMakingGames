using UnityEngine;

public class MirrorState : State {

	private TextController textController;

	public MirrorState(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You see yourself reflected on the mirror, you are ugly as a sin.\n" +
		"The mirror seems loose, maybe with a bit of force it can come out of the wall.\n" +
		"Press T o Take the mirror or R to Return roaming your cell");

		if(Input.GetKeyDown(KeyCode.R)) {
			textController.SetState(new CellState(textController));
		} else if(Input.GetKeyDown(KeyCode.T)) {
			textController.SetState(new CellMirrorState(textController));
		}
	}
}
