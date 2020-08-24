using Godot;

public class PauseLogic : Node {

    private bool Paused;

	private void pause() {
		AudioStreamPlayer pauseSound = (AudioStreamPlayer)GetNode("PauseSound");

		if (Input.IsActionJustPressed("pause") && Paused == false) {
			
            GetTree().Paused = true;
			pauseSound.Play();
			Paused = true;
		} else if (Input.IsActionJustPressed("pause") && Paused == true) {
            GetTree().Paused = false;
			pauseSound.Play();
			Paused = false;
		}
	}

	public override void _Process(float delta) {
		base._Process(delta);
		pause();
	}
}
