using Godot;

public class ChangeScene : Area2D
{

    // Exports string input to editor, drag scene into there after instancing ChangeScene.tscn
    [Export(PropertyHint.File, "*.tscn,*.scn,*.res")]
    private string next_level;

    public override void _PhysicsProcess(float _delta) {
        var bodies = GetOverlappingBodies();

        foreach(PhysicsBody2D body in bodies) {
            // ITS A FUCKING PHYSICSBODY NOT A STRING
            if(body.Name == "Player") {
                GetTree().ChangeScene(next_level);
                GD.Print("Scene changed to ", next_level);
            }
        }
    }
}
