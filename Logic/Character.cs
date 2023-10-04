using Godot;
using System;

public class KBExample : KinematicBody2D
{
	[Signal]
	public delegate void playerHit();
	
	private AnimatedSprite _animatedSprite;
	
	public int Speed = 250;
	private Vector2 _velocity = new Vector2();

	public void GetInput(bool insideWalls)
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		
		// Detect up/down/left/right keystate and only move when pressed
		_velocity = new Vector2();
		if(IsOnFloor())
			GD.Print("On floor");
		if (Input.IsActionPressed("ui_right"))
		{
			_velocity.x += Speed;
			_animatedSprite.Play("right");
		}
		if (Input.IsActionPressed("ui_left"))
		{
			_velocity.x -= Speed;
			_animatedSprite.Play("left");
		}
			
		if (Input.IsActionPressed("ui_down"))
		{
			_velocity.y += Speed;
			_animatedSprite.Play("down");
		}
			
		if (Input.IsActionPressed("ui_up"))
		{
			_velocity.y -= Speed;
			_animatedSprite.Play("up");
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		bool insideWalls = true;
		var collision = MoveAndCollide(_velocity * delta);
		if (collision != null){
			GD.Print("On wall");
			insideWalls = true;
		}
		GetInput(insideWalls);
		//MoveAndCollide(_velocity * delta);
	}
	private void _on_Ball_body_entered(object body)
	{
		// Ball resets when player is hit
		EmitSignal("playerHit");
		GD.Print("Collided");
	}
}
