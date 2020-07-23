using Godot;
using System.Threading;

public class Coin : Area2D {

    // This shit is so damn hacky, why cant there just be a damn yield 
    // fucking piece of shit - https://godotengine.org/article/introducing-csharp-godot

    private bool hasPlayed = false;


    public void _on_CoinSound_finished() {
        QueueFree();
    }

    public override void _PhysicsProcess(float _delta) {
        var bodies = GetOverlappingBodies();
        AudioStreamPlayer coinSound = (AudioStreamPlayer)GetNode("CoinSound");
        ColorRect colorRect = (ColorRect)GetNode("ColorRect");
        foreach(PhysicsBody2D body in bodies) {
            if(body.Name == "Player") {
                if(hasPlayed == false) {
                    hasPlayed = true;
                    coinSound.Play();
                    colorRect.Color = new Color(0,0,0,0);
                }
            }
        }
    }
}
