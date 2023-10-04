using Godot;
using System;

public class Character : KinematicBody2D
{
	[Signal]
	public delegate void playerHit();
	
	[Export]
	public int JumpImpulse { get; set; } = -2000;
	
	private AnimatedSprite _animatedSprite;
	
	public int Speed = 250;
	private Vector2 _velocity = new Vector2();

	public void GetInput(bool insideWalls)
	{
		_animatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
		
		// Detect up/down/left/right keystate and only move when pressed
		_velocity = new Vector2();
		
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
			
		if (!insideWalls && Input.IsActionPressed("ui_select"))
		{
			_velocity.y = JumpImpulse;
		}
		// Once on floor stop gravity
		else if(insideWalls){
			_velocity.y += 50;
		}
	}

	public override void _PhysicsProcess(float delta)
	{
		bool insideWalls = true;
		var collision = MoveAndCollide(_velocity * delta);
		if (collision != null){
			GD.Print("On floor");
			insideWalls = false;
		}
		GetInput(insideWalls);
		//MoveAndCollide(_velocity * delta);
	}
	private void _on_Ball_body_entered(object body)
	{
		if (body is Ball ball){
			// Ball resets when player is hit
			EmitSignal("playerHit");
			GD.Print("Collided");
		}
		
	}
}
