using Godot;

public class PauseLogic : Node {

    private bool Paused;

	public void pause() {
		if (Input.IsActionJustPressed("pause") && Paused == false) {
            GetTree().Paused = true;
			Paused = true;
		} else if (Input.IsActionJustPressed("pause") && Paused == true) {
            GetTree().Paused = false;
			Paused = false;
		}
	}

	public override void _Process(float delta) {
		base._Process(delta);
		pause();
	}
}
