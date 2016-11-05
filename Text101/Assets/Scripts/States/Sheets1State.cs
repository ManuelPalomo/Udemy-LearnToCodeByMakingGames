using UnityEngine;


public class Sheets1State : State {

	private TextController textController;

	public Sheets1State(TextController textController) {
		this.textController = textController;
	}

	public void Handle() {
		textController.SetText("You look the sheets trough the reflection\n" +
		"on your mirror, they look exactly the same: crappy\n" +
		"Press R to return roaming to your cell");

		if(Input.GetKeyDown(KeyCode.R)) {
			textController.SetState(new CellMirrorState(textController));
		}
	}
	
}
