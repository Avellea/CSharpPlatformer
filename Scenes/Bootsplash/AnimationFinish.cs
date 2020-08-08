using Godot;
using System;

public class AnimationFinish : Control {

    public override void _Ready() {
        AnimationPlayer anim = (AnimationPlayer)GetNode("AnimationPlayer");
        anim.Connect("animation_finished", this, "changeScene");
    }

    public void changeScene() {

        GD.Print("Test");

    }

}
