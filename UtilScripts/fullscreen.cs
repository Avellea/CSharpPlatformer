using Godot;

public class fullscreen : Node {

	Config config = new Config();

	public override void _Process(float delta) {
		if(Input.IsActionJustPressed("toggle_fullscreen")) {
			config.Save();
			OS.WindowFullscreen = !OS.WindowFullscreen;
		}
	}
}
