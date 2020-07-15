using Godot;

public class fullscreen : Node {

	public override void _Process(float delta) {
		if(Input.IsActionJustPressed("toggle_fullscreen")) {
			OS.WindowFullscreen = !OS.WindowFullscreen;
		}
	}
}
