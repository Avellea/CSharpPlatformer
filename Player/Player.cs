using Godot;
using System;

public class Player : KinematicBody2D
{

	private int ACCELERATION = 512;
	private int MAX_SPEED    = 64; 
	private int GRAVITY      = 300;
	private int JUMP_FORCE   = 140;

	private float FRICTION   = 0.25f;
	private float AIR_RESIST = 0.02f;

	private Vector2 motion;



	public override void _Ready() {
		#if GODOT_MOBILE
			showMobileUI();
		#endif
	}


	public void showMobileUI() {
		GetNode<Node2D>("MobileUI").Show();
		GD.Print("We're on mobile!");
	}

	//Its a walk function, push the button, the dude be walkin left or right
	public void walk(float delta) {
		AnimationPlayer anim = (AnimationPlayer)GetNode("AnimationPlayer");
		Sprite sprite        = (Sprite)GetNode("Sprite");
		float x_input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		if(x_input != 0) {
			anim.Play("Run");
			motion.x += x_input * ACCELERATION * delta;
			motion.x = Mathf.Clamp(motion.x, -MAX_SPEED, MAX_SPEED);
			sprite.FlipH = x_input < 0;
		} else {
			anim.Play("Stand");
		}
	}

	//Same as above, except this time theres time sensitivity! Short push = short jump, long = long jump.
	public void jump() {
		AnimationPlayer anim = (AnimationPlayer)GetNode("AnimationPlayer");
		AudioStreamPlayer jumpSound = (AudioStreamPlayer)GetNode("JumpSound");
		
		float x_input = Input.GetActionStrength("right") - Input.GetActionStrength("left");
		if(IsOnFloor()) {
			if(x_input == 0) {
				motion.x = Mathf.Lerp(motion.x, 0, FRICTION);
			}
			if(Input.IsActionJustPressed("jump")) {
				jumpSound.Play();
				motion.y = -JUMP_FORCE;
			}
		} else {
			anim.Play("Jump");
			if(Input.IsActionJustReleased("jump") && motion.y < -JUMP_FORCE / 2) {
				motion.y = -JUMP_FORCE / 2;
			}
			if(x_input == 0) {
				motion.x = Mathf.Lerp(motion.x, 0, AIR_RESIST);
			}
		}
	}

	//Actually do the things here.
	public override void _PhysicsProcess(float delta) {
		
		walk(delta);
		motion.y += GRAVITY * delta;
		jump();
		motion = MoveAndSlide(motion, Vector2.Up);
	}

}
