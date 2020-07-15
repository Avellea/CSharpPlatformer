using Godot;

public class ExitGame : Area2D {

    public override void _PhysicsProcess(float _delta) {
        var bodies = GetOverlappingBodies();

        foreach(PhysicsBody2D body in bodies) {
            if(body.Name == "Player") {
                GetTree().Quit();
            }
        }
    }
}
